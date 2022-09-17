Public Class LocationTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, ILocation))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ILocation = New Location(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveAGivenLocationsNameFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Location).Returns((New Mock(Of ILocationData)).Object)
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.Location.ReadName(id))
            End Sub)
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
    Sub ShouldRetrieveCharactersInAGivenLocation()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Characters.ShouldBeEmpty
            End Sub)
    End Sub
End Class
