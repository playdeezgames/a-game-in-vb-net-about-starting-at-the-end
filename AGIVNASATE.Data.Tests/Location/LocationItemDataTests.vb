Public Class LocationItemDataTests
    Private Sub WithLocationItemData(stuffToDo As Action(Of Mock(Of IStore), ILocationItemData))
        Dim store As New Mock(Of IStore)
        Dim subject As ILocationItemData = New LocationItemData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldDetermineHowManyItemsAreAtAGivenLocation()
        WithLocationItemData(
            Sub(store, subject)
                Const locationId = 1L
                subject.ReadCountForLocation(locationId).ShouldBe(0)
                store.Verify(Function(x) x.ReadCountForColumnValue(It.IsAny(Of Action), Views.LocationItems, (Columns.LocationIdColumn, locationId)))
            End Sub)
    End Sub
End Class
