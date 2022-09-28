Public Class RouteDataTests
    Private Sub WithRouteData(stuffToDo As Action(Of Mock(Of IStore), IRouteData))
        Dim store As New Mock(Of IStore)
        Dim subject As IRouteData = New RouteData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadAllOfTheRoutesFromAGivenLocationFromTheStore()
        WithRouteData(
            Sub(store, subject)
                Const id = 1L
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
            Sub(store, subject)
                Const id = 1L
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
            Sub(store, subject)
                Const id = 1L
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
            Sub(store, subject)
                Const id = 1L
                subject.CountForFromLocation(id).ShouldBe(0)
                store.Verify(
                    Function(x) x.ReadCountForColumnValue(Of Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        (Columns.FromLocationIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptToReadTheRouteTypeForAGivenRoute()
        WithRouteData(
            Sub(store, subject)
                Const id = 1L
                subject.ReadRouteType(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        Columns.RouteTypeIdColumn,
                        (Columns.RouteIdColumn, id)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCreateARoute()
        WithRouteData(
            Sub(store, subject)
                Const routeName = "Route Name"
                Const fromLocationId = 1L
                Const toLocationId = 2L
                Const routeTypeId = 3L
                subject.Create(routeTypeId, routeName, fromLocationId, toLocationId)
                store.Verify(
                    Function(x) x.CreateRecord(
                        It.IsAny(Of Action),
                        Tables.Routes,
                        (Columns.RouteTypeIdColumn, routeTypeId),
                        (Columns.RouteNameColumn, routeName),
                        (Columns.FromLocationIdColumn, fromLocationId),
                        (Columns.ToLocationIdColumn, toLocationId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRemoveARouteRecordFromTheSttore()
        WithRouteData(
            Sub(store, subject)
                Const id = 1L
                subject.Clear(id)
            End Sub)
    End Sub
End Class
