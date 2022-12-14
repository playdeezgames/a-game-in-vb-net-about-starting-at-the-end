Module InventoryItemTypeProcessor
    Friend Sub Run(character As ICharacter, itemType As IItemType)
        Dim quantity As Long = character.Inventory.ItemsOfItemType(itemType).Count
        AnsiConsole.Clear()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"{character.Name}'s {itemType.Name}(x{quantity})"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(DropAllText)
        If itemType.CanUse Then
            prompt.AddChoice(UseText)
        End If
        If itemType.CanEquip Then
            prompt.AddChoice(EquipText)
        End If
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case DropAllText
                character.Inventory.DropItemsOfItemType(itemType)
            Case EquipText
                character.Inventory.EquipItemOfItemType(itemType)
            Case UseText
                AnsiConsole.MarkupLine(character.Inventory.UseItemOfItemType(itemType))
                OkPrompt()
        End Select
    End Sub
End Module
