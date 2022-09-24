Module GroundProcessor
    Friend Sub Run(character As ICharacter)
        Dim done = False
        While Not done
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]On the ground:[/]"}
            prompt.AddChoice(NeverMindText)
            Dim table = character.Navigation.Location.Inventory.ItemStacks.
                ToDictionary(
                    Function(x) $"{x.Key.Name}(x{x.Value.Count})",
                    Function(x) x.Key)
            prompt.AddChoices(table.Keys)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
