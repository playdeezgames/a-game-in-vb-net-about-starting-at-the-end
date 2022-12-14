Public Class CharacterNavigationTests
    Inherits BaseGameTests(Of ICharacterNavigation)
    Public Sub New()
        MyBase.New(AddressOf CharacterNavigation.FromId)
    End Sub
    <Fact>
    Sub ShouldAttempToReadLocationForACharacterFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
                subject.Location.ShouldBeNull
                worldData.Verify(Function(x) x.Character.ReadLocation(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldMoveACharacterAlongARoute()
        WithSubject(
            Sub(worldData, id, subject)
                Const locationId = 2L
                worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
                worldData.Setup(Function(x) x.Events.Raise(It.IsAny(Of String), It.IsAny(Of Long())))
                Dim route As New Mock(Of IRoute)
                route.SetupGet(Function(x) x.ToLocation.Id).Returns(locationId)
                route.SetupGet(Function(x) x.RouteType.UseEventName)
                subject.Move(route.Object)
                route.VerifyGet(Function(x) x.Id)
                route.VerifyGet(Function(x) x.ToLocation.Id)
                route.VerifyGet(Function(x) x.RouteType.UseEventName)
                route.VerifyNoOtherCalls()
                worldData.Verify(Sub(x) x.Events.Raise(Nothing, id, 0))
                worldData.Verify(Sub(x) x.Character.WriteLocation(id, locationId))
            End Sub)
    End Sub
End Class
