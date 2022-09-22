Public Class CharacterItemDataTests
    Private Sub WithCharacterItemData(stuffToDo As Action(Of Mock(Of IStore), ICharacterItemData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterItemData = New CharacterItemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheNumberOfItemsThatACharacterHasInTheirInventory()
        WithCharacterItemData(
            Sub(store, subject)
                Const characterId = 1L
                subject.ReadCountForCharacter(characterId).ShouldBe(0)
                store.Verify(Function(x) x.ReadCountForColumnValue(It.IsAny(Of Action), Views.CharacterItems, (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadItemsFromACharactersInventory()
        WithCharacterItemData(
            Sub(store, subject)
                Const characterId = 1L
                subject.ReadForCharacter(characterId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadRecordsWithColumnValue(Of Long, Long, Long)(
                        It.IsAny(Of Action),
                        Views.CharacterItems,
                        (Columns.ItemIdColumn, Columns.ItemTypeIdColumn),
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheItemsFromAGivenCharactersInventoryOfAGivenItemTYpe()
        WithCharacterItemData(
            Sub(store, subject)
                Const characterId = 1L
                Const itemTypeId = 2L
                subject.ReadForItemType(characterId, itemTypeId).ShouldBeNull
            End Sub)
    End Sub
End Class
