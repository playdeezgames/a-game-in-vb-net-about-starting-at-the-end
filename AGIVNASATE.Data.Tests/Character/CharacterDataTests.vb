Public Class CharacterDataTests
    Private Sub WithCharacterData(stuffToDo As Action(Of Mock(Of IStore), ICharacterData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterData = New CharacterData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptReadingALocationFromTheStore()
        WithCharacterData(
            Sub(store, subject)
                Const id = 1L
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
            Sub(store, subject)
                Const id = 1L
                subject.ReadName(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(Of Long)(
                        It.IsAny(Of Action),
                        Tables.Characters,
                        Columns.CharacterNameColumn,
                        (Columns.CharacterIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptWritingALocationForACharacterToTheStore()
        WithCharacterData(
            Sub(store, subject)
                Const id = 1L
                Const locationId = 2L
                subject.WriteLocation(id, locationId)
                store.Verify(
                    Sub(x) x.WriteColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Characters,
                        (Columns.LocationIdColumn, locationId),
                        (Columns.CharacterIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptReadingAllCharactersFromAGivenLocation()
        WithCharacterData(
            Sub(store, subject)
                Const locationId = 1L
                subject.ReadForLocation(locationId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadRecordsWithColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Characters,
                        Columns.CharacterIdColumn,
                        (Columns.LocationIdColumn, locationId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldClearACharacterOutOfTheStore()
        WithCharacterData(
            Sub(store, subject)
                Const characterId = 1L
                subject.Clear(characterId)
                store.Verify(
                    Sub(x) x.ClearForColumnValue(
                        It.IsAny(Of Action),
                        Tables.Characters,
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
End Class
