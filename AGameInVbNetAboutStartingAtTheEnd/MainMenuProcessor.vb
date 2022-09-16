Module MainMenuProcessor
    Friend Sub Run()
        Dim done As Boolean = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoice(EndNewGameText)
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case EndNewGameText
                    Dim game As IGame = New Game()
                    game.EndGame()
                    PlayProcessor.Run(game)
                Case QuitText
                    done = Confirm("Are you sure you want to quit?")
            End Select
        End While
    End Sub
End Module
