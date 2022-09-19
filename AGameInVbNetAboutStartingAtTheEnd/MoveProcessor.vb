Module MoveProcessor
    Friend Sub Run(character As ICharacter)
        Dim routes = character.Navigation.Location.Routes
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Way?[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table = routes.ToDictionary(Function(x) x.Name, Function(x) x)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                'do nothing
            Case Else
                character.Move(table(answer))
        End Select
    End Sub
End Module
