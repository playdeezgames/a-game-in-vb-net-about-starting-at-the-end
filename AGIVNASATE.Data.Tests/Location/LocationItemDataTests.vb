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
    <Fact>
    Sub ShouldReadAllOfTheItemsInAGivenLocation()
        WithLocationItemData(
            Sub(store, subject)
                Const locationId = 1L
                subject.ReadForLocation(locationId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadRecordsWithColumnValue(Of Long, Long, Long)(
                        It.IsAny(Of Action),
                        Views.LocationItems,
                        (Columns.ItemIdColumn, Columns.ItemTypeIdColumn),
                        (Columns.LocationIdColumn, locationId)))
            End Sub)
    End Sub
End Class
