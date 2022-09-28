Public Module BeepTracker

    Dim run_tracker As Boolean = True


    ' ------------------------------------------- Main [DEMONSTRATION CODE]


    'Sub Main(args As String())

    '    ' [IMPORTANT] load music files first

    '    load_music(0, "Funny Skeleton Song.txt")
    '    load_music(1, "Title.txt")
    '    load_music(2, "Test1.txt")
    '    load_music(3, "Final Boss.txt")

    '    ' easy to start

    '    start_tracker_thread()

    '    ' call change_music function at start to be safe

    '    change_music(3)

    '    '  test to show that it can run along side game

    '    While True
    '        Threading.Thread.Sleep(100)
    '        'Console.WriteLine("text")
    '        'Console.ReadLine()
    '    End While

    '    ' [IMPORTANT] end tracker or thread will keep going
    '    '    |   |
    '    '    V   V
    '    end_tracker_thread()
    'End Sub


    ' ------------------------------------------- Start


    Sub start_tracker_thread()
        run_tracker = True
        Dim music_thread As New Threading.Thread(AddressOf play_music)
        music_thread.Start()
    End Sub


    ' ------------------------------------------- End


    Sub end_tracker_thread()
        run_tracker = False
    End Sub



    ' #############################################################################################
    '                                            Commands
    ' #############################################################################################



    Dim command_index As Integer = 0
    Dim read_commands As Boolean = True

    Dim music_id As Integer = 0

    Dim loop_index As Integer = 0
    Dim loop_count As Integer = 0

    ' queue change

    Dim queue_music_change As Boolean = False
    Dim queued_music_id As Integer = 0



    ' ------------------------------------------- Run Command


    Sub run_command()

        ' get command

        Dim data As ArrayList = music_data.GetValueOrDefault(music_id)
        If command_index >= data.Count Then
            command_index = 0
        End If
        Dim command As String = CStr(data(command_index))

        ' check type

        If Not VarType(command) = vbString Then
            command_index += 1
            Return
        End If

        ' toggle reading

        If command.Contains("READ") Then
            command_index += 1
            Select Case CInt(data(command_index))
                Case 0
                    read_commands = False
                Case 1
                    read_commands = True
                Case 2
                    read_commands = Not read_commands
            End Select

            ' get type

        ElseIf read_commands Then
            Select Case command

                ' bpm

                Case "BPM"
                    command_index += 1
                    bpm = CInt(data(command_index))
                    ms_per_note = CInt(BPM_TO_MS / bpm)

                ' wait

                Case "WAIT"
                    command_index += 1
                    Threading.Thread.Sleep(CInt(data(command_index)) * ms_per_note)

                ' beep

                Case "BEEP"
                    command_index += 1
                    play_note(CInt(data(command_index)), CInt(data(command_index + 1)), CInt(data(command_index + 2)) * ms_per_note)
                    command_index += 2

                ' kick

                Case "KICK"
                    command_index += 1
                    play_kick_drum(CInt(data(command_index)))

                ' snare

                Case "SNARE"
                    command_index += 1
                    play_snare_drum(CInt(data(command_index)))

                ' loop

                Case "LOOP"
                    command_index += 1
                    Select Case CStr(data(command_index))
                        Case "START"
                            command_index += 1
                            loop_count = CInt(data(command_index))
                            loop_index = command_index
                        Case "END"
                            loop_count -= 1
                            If loop_count > 0 Then
                                command_index = loop_index
                            End If
                    End Select
            End Select
        End If

        ' increment

        command_index += 1

    End Sub



    ' #############################################################################################
    '                                            Music
    ' #############################################################################################



    Const BPM_TO_MS As Integer = 15000

    Private ReadOnly music_data As New Dictionary(Of Integer, ArrayList)()

    Dim bpm As Integer = 120
    Dim ms_per_note As Integer = 125


    ' ------------------------------------------- Play Music


    Sub play_music()

        ' load music



        ' begin loop

        While run_tracker
            run_command()
            If queue_music_change Then
                queue_music_change = False
                If Not music_id = queued_music_id Then
                    music_id = queued_music_id
                    command_index = 0
                End If
            End If
        End While
    End Sub


    ' ------------------------------------------- Load Music


    Sub load_music(to_id As Integer, file_location As String)

        ' get file

        'Console.WriteLine("loading file : " + file_location)
        Dim file_str As String = System.IO.File.ReadAllText(file_location)

        ' loop through file lines

        Dim data As ArrayList = New ArrayList
        Dim lines() As String = Split(file_str, Chr(10))
        For Each item In lines

            ' get line data

            Dim instrunction() As String = Split(item)

            ' add data

            data.Add(instrunction(0))
            Select Case instrunction(0)

                ' bpm

                Case "BPM"
                    data.Add(CInt(instrunction(1)))

                ' wait

                Case "WAIT"
                    data.Add(CInt(instrunction(1)))

                ' beep

                Case "BEEP"
                    data.Add(string_to_note_index(instrunction(1)))
                    data.Add(CInt(instrunction(2)))
                    data.Add(CInt(instrunction(3)))

                ' kick

                Case "KICK"
                    data.Add(CInt(instrunction(1)))

                ' snare

                Case "SNARE"
                    data.Add(CInt(instrunction(1)))

                ' read

                Case "READ"
                    data.Add(CInt(instrunction(1)))

                ' loop

                Case "LOOP"
                    If instrunction(1).Contains("START") Then
                        data.Add("START")
                        data.Add(CInt(instrunction(2)))
                    ElseIf instrunction(1).Contains("END") Then
                        data.Add("END")
                    End If
            End Select
        Next

        ' add to music data list

        music_data.Add(to_id, data)
    End Sub


    ' ------------------------------------------- Play Music


    Sub change_music(new_music_id As Integer)
        read_commands = True
        queue_music_change = True
        queued_music_id = new_music_id
    End Sub



    ' #############################################################################################
    '                                            Notes
    ' #############################################################################################




    ' ------------------------------------------- Play Note


    Public Function string_to_note_index(note As String) As Integer
        Select Case note
            Case "A"
                Return 0
            Case "A#"
                Return 1
            Case "B"
                Return 2
            Case "C"
                Return 3
            Case "C#"
                Return 4
            Case "D"
                Return 5
            Case "D#"
                Return 6
            Case "E"
                Return 7
            Case "F"
                Return 8
            Case "F#"
                Return 9
            Case "G"
                Return 10
            Case "G#"
                Return 11
        End Select
        Return 0
    End Function


    ' ------------------------------------------- Play Note


    Sub play_note(note As Int32, octave As Int32, duation As Int32)
        Console.Beep(CInt((2 ^ (note / 12 + octave - 2)) * 220), duation)
    End Sub


    ' ------------------------------------------- Play Kick Drum


    Sub play_kick_drum(duation As Int32)
        Console.Beep(100, 50)
        Threading.Thread.Sleep(Math.Max(duation * ms_per_note - 50, 1))
    End Sub


    ' ------------------------------------------- Play Snare Drum


    Sub play_snare_drum(duation As Int32)
        Console.Beep(200, 50)
        Threading.Thread.Sleep(Math.Max(duation * ms_per_note - 50, 1))
    End Sub

End Module
