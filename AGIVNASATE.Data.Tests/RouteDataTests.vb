Public Class RouteDataTests
    Private Sub WithRouteData(stuffToDo As Action(Of Mock(Of IStore), Long, IRouteData))
        Const id = 1L
        Dim store As New Mock(Of IStore)
        Dim subject As IRouteData = New RouteData(store.Object)
        stuffToDo(store, id, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadAllOfTheRoutesFromAGivenLocationFromTheStore()
        WithRouteData(
            Sub(store, id, subject)
                subject.ReadForFromLocation(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadRecordsWithColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        Columns.RouteIdColumn,
                        (Columns.FromLocationIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptToReadNameFromTheStore()
        WithRouteData(
            Sub(store, id, subject)
                subject.ReadName(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(Of Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        Columns.RouteNameColumn,
                        (Columns.RouteIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptToReadToLocationFromTheStore()
        WithRouteData(
            Sub(store, id, subject)
                subject.ReadToLocation(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        Columns.ToLocationIdColumn,
                        (Columns.RouteIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptToReadTheCountOfRoutesForAGivenLocation()
        WithRouteData(
            Sub(store, id, subject)
                subject.CountForFromLocation(id).ShouldBe(0)
                store.Verify(
                    Function(x) x.ReadCountForColumnValue(Of Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        (Columns.FromLocationIdColumn, id)))
            End Sub)
    End Sub
End Class
