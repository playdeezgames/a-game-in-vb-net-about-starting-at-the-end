Public Class CharacterStatisticDataTests
    Private Sub WithCharacterStatisticData(stuffToDo As Action(Of Mock(Of IStore), Long, ICharacterStatisticData))
        Const id = 1L
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterStatisticData = New CharacterStatisticData(store.Object)
        stuffToDo(store, id, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptToReadAStatisticValueForAGivenCharacterAndStatisticType()
        WithCharacterStatisticData(
            Sub(store, id, subject)
                Const characterId = 1L
                Const statisticTypeId = 2L
                subject.Read(characterId, statisticTypeId)
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long, Long)(
                    It.IsAny(Of Action),
                    Tables.CharacterStatistics,
                    Columns.StatisticValueColumn,
                    (Columns.CharacterIdColumn, characterId),
                    (Columns.StatisticTypeIdColumn, statisticTypeId)))
            End Sub)
    End Sub
End Class
