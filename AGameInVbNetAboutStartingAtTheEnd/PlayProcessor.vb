Module PlayProcessor
    Friend Sub Run(game As IGame)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("So, you played the game!")
        OkPrompt()
    End Sub
End Module
