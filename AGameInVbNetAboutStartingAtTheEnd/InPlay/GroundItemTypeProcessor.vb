Module GroundItemTypeProcessor
    Friend Sub Run(character As ICharacter, location As ILocation, itemType As IItemType)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemType.Name}(s) on the ground at {location.Name}:[/]"}
            prompt.AddChoice(NeverMindText)
            Select Case AnsiConsole.Prompt(prompt)
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
