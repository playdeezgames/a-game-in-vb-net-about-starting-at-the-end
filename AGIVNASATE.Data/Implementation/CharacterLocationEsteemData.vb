Public Class CharacterLocationEsteemData
    Inherits BaseData
    Implements ICharacterLocationEsteemData
    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub
    Public Function ReadForFromCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long)) Implements ICharacterLocationEsteemData.ReadForFromCharacter
        Return Store.ReadRecordsWithColumnValue(Of Long, Long, Long)(
            AddressOf NoInitializer,
            Tables.CharacterLocationEsteems,
            (Columns.ToCharacterIdColumn, Columns.EsteemColumn),
            (Columns.FromCharacterIdColumn, characterId))
    End Function
End Class
