Public Class CharacterStatisticDataTests
    Private Sub WithCharacterStatisticData(stuffToDo As Action(Of Mock(Of IStore), ICharacterStatisticData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterStatisticData = New CharacterStatisticData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptToReadAStatisticValueForAGivenCharacterAndStatisticType()
        WithCharacterStatisticData(
            Sub(store, subject)
                Const characterId = 1L
                Const statisticTypeId = 2L
                subject.Read(characterId, statisticTypeId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long, Long)(
                    It.IsAny(Of Action),
                    Tables.CharacterStatistics,
                    Columns.StatisticValueColumn,
                    (Columns.CharacterIdColumn, characterId),
                    (Columns.StatisticTypeIdColumn, statisticTypeId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldWriteAStatisticValueToTheStoreForAGivenCharactersGivenStatisticType()
        WithCharacterStatisticData(
            Sub(store, subject)
                Const characterId = 1L
                Const statisticTypeId = 2L
                Const statisticValue = 3L
                subject.Write(characterId, statisticTypeId, statisticValue)
                store.Verify(Sub(x) x.ReplaceRecord(
                             It.IsAny(Of Action),
                             Tables.CharacterStatistics,
                             (Columns.CharacterIdColumn, characterId),
                             (Columns.StatisticTypeIdColumn, statisticTypeId),
                             (Columns.StatisticValueColumn, statisticValue)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldClearOutStatisticsForAGiveCharacter()
        WithCharacterStatisticData(
            Sub(store, subject)
                Const characterId = 1L
                subject.ClearForCharacter(characterId)
                store.Verify(
                    Sub(x) x.ClearForColumnValue(
                        It.IsAny(Of Action),
                        Tables.CharacterStatistics,
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
End Class
