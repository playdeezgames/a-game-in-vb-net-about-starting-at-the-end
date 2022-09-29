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
End Class
