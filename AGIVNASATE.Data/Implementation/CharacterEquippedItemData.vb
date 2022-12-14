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

    Public Sub ClearForCharacter(characterId As Long) Implements ICharacterEquippedItemData.ClearForCharacter
        Store.ClearForColumnValue(AddressOf NoInitializer, Tables.CharacterEquippedItems, (Columns.CharacterIdColumn, characterId))
    End Sub

    Public Function CountForCharacter(characterId As Long) As Long Implements ICharacterEquippedItemData.CountForCharacter
        Return Store.ReadCountForColumnValue(
            AddressOf NoInitializer,
            Tables.CharacterEquippedItems,
            (Columns.CharacterIdColumn, characterId))
    End Function

    Public Function ReadForCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long)) Implements ICharacterEquippedItemData.ReadForCharacter
        Return Store.ReadRecordsWithColumnValue(Of Long, Long, Long)(
            AddressOf NoInitializer,
            Tables.CharacterEquippedItems,
            (Columns.EquipSlotIdColumn, Columns.ItemIdColumn),
            (Columns.CharacterIdColumn, characterId))
    End Function
End Class
