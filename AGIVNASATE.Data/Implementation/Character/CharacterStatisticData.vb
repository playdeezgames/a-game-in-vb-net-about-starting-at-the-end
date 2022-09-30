Public Class CharacterStatisticData
    Inherits BaseData
    Implements ICharacterStatisticData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub Write(characterId As Long, statisticTypeId As Long, statisticValue As Long) Implements ICharacterStatisticData.Write
        Store.ReplaceRecord(
            AddressOf NoInitializer,
            Tables.CharacterStatistics,
            (Columns.CharacterIdColumn, characterId),
            (Columns.StatisticTypeIdColumn, statisticTypeId),
            (Columns.StatisticValueColumn, statisticValue))
    End Sub

    Public Sub ClearForCharacter(characterId As Long) Implements ICharacterStatisticData.ClearForCharacter
        Store.ClearForColumnValue(
            AddressOf NoInitializer,
            Tables.CharacterStatistics,
            (Columns.CharacterIdColumn, characterId))
    End Sub

    Public Function Read(characterId As Long, statisticTypeId As Long) As Long? Implements ICharacterStatisticData.Read
        Return Store.ReadColumnValue(Of Long, Long, Long)(
            AddressOf NoInitializer,
            Tables.CharacterStatistics,
            Columns.StatisticValueColumn,
            (Columns.CharacterIdColumn, characterId),
            (Columns.StatisticTypeIdColumn, statisticTypeId))
    End Function
End Class
