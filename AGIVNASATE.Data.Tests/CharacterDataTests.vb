Public Class CharacterDataTests
    Private Sub WithCharacterData(stuffToDo As Action(Of Mock(Of IStore), Long, ICharacterData))
        Const id = 1L
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterData = New CharacterData(store.Object)
        stuffToDo(store, id, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptReadingALocationFromTheStore()
        WithCharacterData(
            Sub(store, id, subject)
                subject.ReadLocation(id).ShouldBeNull
                store.Verify(
            Function(x) x.ReadColumnValue(Of Long, Long)(
                It.IsAny(Of Action),
                Tables.Characters,
                Columns.LocationIdColumn,
                (Columns.CharacterIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptReadingANameFromTheStore()
        WithCharacterData(
            Sub(store, id, subject)
                subject.ReadName(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(Of Long)(
                        It.IsAny(Of Action),
                        Tables.Characters,
                        Columns.CharacterNameColumn,
                        (Columns.CharacterIdColumn, id)))
            End Sub)
    End Sub
End Class
