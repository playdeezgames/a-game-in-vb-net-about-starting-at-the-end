Public Class CharacterLocationEsteemDataTests
    Private Sub WithCharacterLocationEsteemData(stuffToDo As Action(Of Mock(Of IStore), ICharacterLocationEsteemData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterLocationEsteemData = New CharacterLocationEsteemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldFetchTheOtherCharactersAndTheGivenCharactersStanceTowardsThemFromTheStore()
        WithCharacterLocationEsteemData(
            Sub(store, subject)
                Const characterId = 1L
                subject.ReadForFromCharacter(characterId)
                store.Verify(
                    Function(x) x.ReadRecordsWithColumnValue(Of Long, Long, Long)(
                        It.IsAny(Of Action),
                        Tables.CharacterLocationEsteems,
                        (Columns.ToCharacterIdColumn, Columns.EsteemColumn),
                        (Columns.FromCharacterIdColumn, characterId)))
            End Sub)
    End Sub
End Class
