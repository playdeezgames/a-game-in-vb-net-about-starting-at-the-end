Module MainMenuProcessor
    Friend Sub Run()
        Dim done As Boolean = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    done = Confirm("Are you sure you want to quit?")
            End Select
        End While
    End Sub
End Module
