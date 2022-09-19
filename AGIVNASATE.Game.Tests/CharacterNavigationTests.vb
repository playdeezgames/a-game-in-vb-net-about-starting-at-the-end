Public Class CharacterNavigationTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, ICharacterNavigation))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ICharacterNavigation = New CharacterNavigation(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
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
                Dim route As New Mock(Of IRoute)
                route.SetupGet(Function(x) x.ToLocation.Id).Returns(locationId)
                subject.Move(route.Object)
                route.VerifyGet(Function(x) x.ToLocation.Id)
                route.VerifyNoOtherCalls()
                worldData.Verify(Sub(x) x.Character.WriteLocation(id, locationId))
            End Sub)
    End Sub
End Class
