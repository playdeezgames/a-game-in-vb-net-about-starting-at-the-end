Module InventoryItemTypeProcessor
    Friend Sub Run(character As ICharacter, itemType As IItemType)
        Dim done = False
        While Not done
            Dim quantity As Long = character.Inventory.ItemsOfItemType(itemType).Count
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"{character.Name}'s {itemType.Name}(x{quantity})"}
            prompt.AddChoice(NeverMindText)
            prompt.AddChoice(DropAllText)
            If itemType.CanUse Then
                prompt.AddChoice(UseText)
            End If
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case DropAllText
                    character.Inventory.DropItemsOfItemType(itemType)
                    done = True
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
