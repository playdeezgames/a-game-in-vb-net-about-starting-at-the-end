Public Class RouteTests
    Inherits BaseGameTests(Of IRoute)
    Sub New()
        MyBase.New(AddressOf Route.FromId)
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
            End Sub)
    End Sub
    <Fact>
    Sub RetrieveAGivenRoutesNameFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Route).Returns((New Mock(Of IRouteData)).Object)
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.Route.ReadName(id))
            End Sub)
    End Sub
    <Fact>
    Sub RetrieveAGivenRoutesToLocationFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Route).Returns((New Mock(Of IRouteData)).Object)
                subject.ToLocation.ShouldBeNull
                worldData.Verify(Function(x) x.Route.ReadToLocation(id))
            End Sub)
    End Sub
    <Fact>
    Sub RetrieveAGivenRoutesRouteType()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.Route.ReadRouteType(It.IsAny(Of Long)))
                subject.RouteType.ShouldBeNull
                worldData.Verify(Function(x) x.Route.ReadRouteType(id))
            End Sub)
    End Sub
    <Fact>
    Sub DestroyAGivenRoute()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Destroy()
            End Sub)
    End Sub
End Class
