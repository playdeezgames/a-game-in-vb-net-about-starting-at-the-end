Public Class CharacterEquippedItemData
    Inherits BaseData
    Implements ICharacterEquippedItemData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub Write(characterId As Long, equipSlotId As Long, itemId As Long) Implements ICharacterEquippedItemData.Write
        Store.ReplaceRecord(
            AddressOf NoInitializer,
            Tables.CharacterEquippedItems,
            (Columns.CharacterIdColumn, characterId),
            (Columns.EquipSlotIdColumn, equipSlotId),
            (Columns.ItemIdColumn, itemId))
    End Sub

    Public Function CountForCharacter(characterId As Long) As Long Implements ICharacterEquippedItemData.CountForCharacter
        Return 0L
    End Function
End Class
