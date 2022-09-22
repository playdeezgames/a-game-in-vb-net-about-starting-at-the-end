Module InventoryProcessor
    Friend Sub Run(character As ICharacter)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"{character.Name}'s Inventory:"}
            prompt.AddChoice(NeverMindText)
            Dim table = character.ItemStacks.
                ToDictionary(
                    Function(x) $"{x.Key.Name}(x{x.Value.Count})",
                    Function(x) x.Key)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
