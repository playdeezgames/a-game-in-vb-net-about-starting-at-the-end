Public Class CharacterStatisticBuffDataTests
    Private Sub WithCharacterStatisticBuffData(stuffToDo As Action(Of Mock(Of IStore), ICharacterStatisticBuffData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterStatisticBuffData = New CharacterStatisticBuffData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldRetrieveTheStatisticBuffsForEquippedItemsOnAGivenCharacter()
        WithCharacterStatisticBuffData(
            Sub(store, subject)
                Dim characterId = 1L
                Dim statisticTypeId = 2L
                subject.Read(characterId, statisticTypeId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long, Long)(
                        It.IsAny(Of Action),
                        Views.CharacterStatisticBuffs,
                        Columns.BuffColumn,
                        (Columns.CharacterIdColumn, characterId),
                        (Columns.StatisticTypeIdColumn, statisticTypeId)))
            End Sub)
    End Sub
End Class
