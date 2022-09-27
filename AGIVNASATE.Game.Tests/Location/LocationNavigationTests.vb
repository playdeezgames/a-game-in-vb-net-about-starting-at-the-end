Public Class LocationNavigationTests
    Inherits BaseGameTests(Of ILocationNavigation)
    Sub New()
        MyBase.New(AddressOf LocationNavigation.FromId)
    End Sub
    <Fact>
    Sub ShouldRetrieveAGivenLocationsExistenceOfOutgoingRoutesFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Route).Returns((New Mock(Of IRouteData)).Object)
                subject.HasRoutes().ShouldBeFalse
                worldData.Verify(Function(x) x.Route.CountForFromLocation(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveAGivenLocationsOutgoingRoutesFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Route).Returns((New Mock(Of IRouteData)).Object)
                subject.Routes.ShouldBeEmpty
                worldData.Verify(Function(x) x.Route.ReadForFromLocation(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCreateARouteFromTheCurrentLocationToAnotherLocation()
        WithSubject(
            Sub(worldData, id, subject)
                Const routeName = "Route Name"
                Const toLocationId = 2L
                Const routeTypeId = 3L
                worldData.Setup(
                    Function(x) x.Route.Create(
                        It.IsAny(Of Long),
                        It.IsAny(Of String),
                        It.IsAny(Of Long),
                        It.IsAny(Of Long)))
                subject.CreateRoute(RouteType.FromId(worldData.Object, routeTypeId), routeName, Location.FromId(worldData.Object, toLocationId))
                worldData.Verify(Function(x) x.Route.Create(routeTypeId, routeName, id, toLocationId))
            End Sub)
    End Sub
End Class
