Public Class CharacterEquippedItemDataTests
    Private Sub WithCharacterEquippedItemData(stuffToDo As Action(Of Mock(Of IStore), ICharacterEquippedItemData))
        Dim store As New Mock(Of IStore)
        Dim subject As ICharacterEquippedItemData = New CharacterEquippedItemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldWriteAnItemIntoAGivenEquipSlotOfAGivenCharacter()
        WithCharacterEquippedItemData(
            Sub(store, subject)
                Const characterId = 1L
                Const equipSlotId = 2L
                Const itemId = 3L
                subject.Write(characterId, equipSlotId, itemId)
                store.Verify(
                    Sub(x) x.ReplaceRecord(
                        It.IsAny(Of Action),
                        Tables.CharacterEquippedItems,
                        (Columns.CharacterIdColumn, characterId),
                        (Columns.EquipSlotIdColumn, equipSlotId),
                        (Columns.ItemIdColumn, itemId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadHowManyItemsAreEquippedForAGivenCharacter()
        WithCharacterEquippedItemData(
            Sub(store, subject)
                Const characterId = 1L
                subject.CountForCharacter(characterId).ShouldBe(0)
                store.Verify(
                    Function(x) x.ReadCountForColumnValue(
                        It.IsAny(Of Action),
                        Tables.CharacterEquippedItems,
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadTheEquippedItemSlotsForAGivenCharacter()
        WithCharacterEquippedItemData(
            Sub(store, subject)
                Const characterId = 1L
                subject.ReadForCharacter(characterId).ShouldBeNull
            End Sub)
    End Sub
End Class
