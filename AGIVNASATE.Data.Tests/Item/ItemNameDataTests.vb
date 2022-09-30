Public Class ItemNameDataTests
    Private Sub WithItemNameData(stuffToDo As Action(Of Mock(Of IStore), IItemNameData))
        Dim store As New Mock(Of IStore)
        Dim subject As IItemNameData = New ItemNameData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheNameOfAnItemFromTheDataStore()
        WithItemNameData(
            Sub(store, subject)
                Const itemId = 1L
                subject.Read(itemId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Views.ItemNames,
                        Columns.ItemNameColumn,
                        (Columns.ItemIdColumn, itemId)))
            End Sub)
    End Sub
End Class
