Public Class WorldTests
    <Fact>
    Sub ShouldRetrieveThePlayersCharacterFromTheData()
        Dim worldData As New Mock(Of IWorldData)
        worldData.SetupGet(Function(x) x.Player).Returns((New Mock(Of IPlayerData)).Object)
        Dim subject As IWorld = New World(worldData.Object)
        subject.PlayerCharacter.ShouldBeNull
        worldData.Verify(Function(x) x.Player.ReadCharacterId())
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldCallSaveFunctionForWorldData()
        Const filename = "blah.db"
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As IWorld = New World(worldData.Object)
        subject.Save(filename)
        worldData.Verify(Sub(x) x.Save(filename))
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldFetchTheStartingLocationOfAWorld()
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As IWorld = New World(worldData.Object)
        subject.StartLocation.ShouldBeNull
    End Sub
    <Fact>
    Sub ShouldFetchARouteTypeByIdentifier()
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As IWorld = New World(worldData.Object)
        Const routeTypeId = 1L
        subject.RouteTypes(routeTypeId).Id.ShouldBe(routeTypeId)
    End Sub
End Class


