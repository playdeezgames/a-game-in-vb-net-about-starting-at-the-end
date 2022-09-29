Module EquipmentProcessor
    Friend Sub Run(character As ICharacter)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim equippedItems As IReadOnlyDictionary(Of IEquipSlot, IItem) = character.EquippedItems
            Dim table = equippedItems.ToDictionary(Function(x) $"{x.Key.Name}: {x.Value.Id}", Function(x) x.Key)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{character.Name}'s Equipment:[/]"}
            prompt.AddChoice(NeverMindText)
            prompt.AddChoices(table.Keys)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
