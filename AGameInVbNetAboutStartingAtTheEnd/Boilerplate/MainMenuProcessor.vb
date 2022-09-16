﻿Module MainMenuProcessor
    Friend Sub Run()
        Dim done As Boolean = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoice(StartNewGameText)
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case StartNewGameText
                    Dim store As IStore = New Store(Constants.DatabaseFileName)
                    store.Reset()
                    Dim game As IGame = New Game(New WorldData(store))
                    game.StartGame()
                    PlayProcessor.Run(game)
                Case QuitText
                    done = Confirm("Are you sure you want to quit?")
            End Select
        End While
    End Sub
End Module