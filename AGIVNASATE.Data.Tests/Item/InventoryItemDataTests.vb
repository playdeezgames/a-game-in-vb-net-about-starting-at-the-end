Public Class InventoryItemDataTests
    Private Sub WithItemData(stuffToDo As Action(Of Mock(Of IStore), IInventoryItemData))
        Dim store As New Mock(Of IStore)
        Dim subject As IInventoryItemData = New InventoryItemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAssignTheInventoryAssociatedWithAGivenItem()
        WithItemData(
            Sub(store, subject)
                Const itemId = 1L
                Const inventoryId = 2L
                subject.Write(itemId, inventoryId)
                store.Verify(
                    Sub(x) x.ReplaceRecord(
                        It.IsAny(Of Action),
                        Tables.InventoryItems,
                        (Columns.InventoryIdColumn, inventoryId),
                        (Columns.ItemIdColumn, itemId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRemoveRecordsFromTheInventoryItemsInTheStore()
        WithItemData(
            Sub(store, subject)
                Const itemId = 1L
                subject.ClearForItem(itemId)
                store.Verify(
                    Sub(x) x.ClearForColumnValue(
                        It.IsAny(Of Action),
                        Tables.InventoryItems,
                        (Columns.ItemIdColumn, itemId)))
            End Sub)
    End Sub
End Class
