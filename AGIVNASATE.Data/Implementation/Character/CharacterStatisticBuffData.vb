Public Class CharacterStatisticBuffData
    Inherits BaseData
    Implements ICharacterStatisticBuffData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function Read(characterId As Long, statisticTypeId As Long) As Long? Implements ICharacterStatisticBuffData.Read
        Return Store.ReadColumnValue(Of Long, Long, Long)(
            AddressOf NoInitializer,
            Views.CharacterStatisticBuffs,
            Columns.BuffColumn,
            (Columns.CharacterIdColumn, characterId),
            (Columns.StatisticTypeIdColumn, statisticTypeId))
    End Function
End Class
