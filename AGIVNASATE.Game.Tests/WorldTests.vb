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
End Class


