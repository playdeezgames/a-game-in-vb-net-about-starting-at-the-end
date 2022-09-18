Public Class WorldDataTests
    <Fact>
    Sub ShouldHaveSubobjects()
        Dim store As New Mock(Of IStore)
        Dim worldData As IWorldData = New WorldData(store.Object)
        worldData.Character.ShouldNotBeNull
        worldData.CharacterLocationEsteem.ShouldNotBeNull
        worldData.CharacterStatistic.ShouldNotBeNull
        worldData.Location.ShouldNotBeNull
        worldData.Player.ShouldNotBeNull
        worldData.Route.ShouldNotBeNull
        store.VerifyNoOtherCalls()
    End Sub
End Class


