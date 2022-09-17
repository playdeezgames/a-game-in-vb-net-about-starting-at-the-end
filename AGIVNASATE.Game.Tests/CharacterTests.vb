Public Class CharacterTests
    <Fact>
    Sub ShouldHoldAnIdNumber()
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ICharacter = New Character(worldData.Object, id)
        subject.Id.ShouldBe(id)
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttempToReadLocationForACharacterFromTheData()
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
        Dim subject As ICharacter = New Character(worldData.Object, id)
        subject.Location.ShouldBeNull
        worldData.Verify(Function(x) x.Character.ReadLocation(id))
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptToReadNameForACharacterFromTheData()
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
        Dim subject As ICharacter = New Character(worldData.Object, id)
        subject.Name.ShouldBeNull
        worldData.Verify(Function(x) x.Character.ReadName(id))
        worldData.VerifyNoOtherCalls()
    End Sub
End Class
