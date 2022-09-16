Public Class CharacterDataTests
    <Fact>
    Sub ShouldAttemptReadingALocationFromTheStore()
        Const characterId = 1L
        Dim store As New Mock(Of IStore)
        Dim characterData As ICharacterData = New CharacterData(store.Object)
        characterData.ReadLocation(characterId).ShouldBeNull
        store.Verify(
            Function(x) x.ReadColumnValue(Of Long, Long)(
                It.IsAny(Of Action),
                Tables.Characters,
                Columns.LocationIdColumn,
                (Columns.CharacterIdColumn, characterId)))
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptReadingANameFromTheStore()
        Const characterId = 1L
        Dim store As New Mock(Of IStore)
        Dim characterData As ICharacterData = New CharacterData(store.Object)
        characterData.ReadName(characterId).ShouldBeNull
        store.Verify(
            Function(x) x.ReadColumnString(Of Long)(
                It.IsAny(Of Action),
                Tables.Characters,
                Columns.CharacterNameColumn,
                (Columns.CharacterIdColumn, characterId)))
        store.VerifyNoOtherCalls()
    End Sub
End Class
