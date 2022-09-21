Public Class CharacterItemData
    Inherits BaseData
    Implements ICharacterItemData
    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub
    Public Function ReadCountForCharacter(characterId As Long) As Long Implements ICharacterItemData.ReadCountForCharacter
        Return Store.ReadCountForColumnValue(
            AddressOf NoInitializer,
            Views.CharacterItems,
            (Columns.CharacterIdColumn, characterId))
    End Function

    Public Function ReadForCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long)) Implements ICharacterItemData.ReadForCharacter
        Return Store.ReadRecordsWithColumnValue(Of Long, Long, Long)(
            AddressOf NoInitializer,
            Views.CharacterItems,
            (Columns.ItemIdColumn, Columns.ItemTypeIdColumn),
            (Columns.CharacterIdColumn, characterId))
    End Function
End Class
