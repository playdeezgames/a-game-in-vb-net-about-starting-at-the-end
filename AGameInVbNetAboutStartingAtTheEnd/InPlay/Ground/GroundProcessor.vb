Module GroundProcessor
    Friend Sub Run(character As ICharacter)
        Dim done = False
        While Not done
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]On the ground:[/]"}
            prompt.AddChoice(NeverMindText)
            Dim location = character.Navigation.Location
            Dim table = location.Inventory.ItemStacks.
                ToDictionary(
                    Function(x) $"{x.Key.Name}(x{x.Value.Count})",
                    Function(x) x.Key)
            prompt.AddChoices(table.Keys)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    GroundItemTypeProcessor.Run(character, table(answer))
            End Select
        End While
    End Sub
End Module
