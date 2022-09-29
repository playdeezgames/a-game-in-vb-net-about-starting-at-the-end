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
End Class
