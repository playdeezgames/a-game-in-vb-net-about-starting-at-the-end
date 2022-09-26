Public Class ItemDataTests
    Private Sub WithItemData(stuffToDo As Action(Of Mock(Of IStore), IItemData))
        Dim store As New Mock(Of IStore)
        Dim subject As IItemData = New ItemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldRemoveInformationPertainingToAGivenItemFromTheDataStore()
        WithItemData(
            Sub(store, subject)
                Const itemId = 1L
                subject.Clear(itemId)
                store.Verify(
                    Sub(x) x.ClearForColumnValue(
                        It.IsAny(Of Action),
                        Tables.InventoryItems,
                        (Columns.ItemIdColumn, itemId)))
                store.Verify(
                    Sub(x) x.ClearForColumnValue(
                        It.IsAny(Of Action),
                        Tables.Items,
                        (Columns.ItemIdColumn, itemId)))
            End Sub)
    End Sub
End Class
