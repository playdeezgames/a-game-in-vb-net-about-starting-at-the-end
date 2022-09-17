Module PlayProcessor
    Friend Sub Run(world As IWorld)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim character = world.PlayerCharacter
            Dim location = character.Location
            AnsiConsole.MarkupLine($"{character.Name} is at {location.Name}.")
            AnsiConsole.MarkupLine("Statistics:")
            Dim satiety = character.Satiety
            AnsiConsole.MarkupLine($"* {satiety.Item1}/{satiety.Item2}")
            If location.HasRoutes Then
                AnsiConsole.MarkupLine("Routes:")
                For Each route In location.Routes
                    AnsiConsole.MarkupLine($"* {route.Name}")
                Next
            End If

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If location.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = Confirm("Are you sure you want to abandon the game?")
                Case MoveText
                    MoveProcessor.Run(world)
            End Select
        End While
    End Sub
End Module
