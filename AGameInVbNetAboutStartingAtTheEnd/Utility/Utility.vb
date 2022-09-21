Module Utility
    Sub OkPrompt()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice(OkText)
        AnsiConsole.Prompt(prompt)
    End Sub
    Function Confirm(text As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[red]{text}[/]"}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
    Function CharacterAndHealth(character As ICharacter) As String
        Dim health = character.Statistics.Health
        Return $"{character.Name} ({health.Item1}/{health.Item2})"
    End Function
End Module
