Module PlayProcessor
    Friend Sub Run(game As IGame)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim character = game.PlayerCharacter
            Dim location = character.Location
            AnsiConsole.MarkupLine($"{character.Name} is at {location.Name}.")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = Confirm("Are you sure you want to abandon the game?")
            End Select
        End While
    End Sub
End Module
