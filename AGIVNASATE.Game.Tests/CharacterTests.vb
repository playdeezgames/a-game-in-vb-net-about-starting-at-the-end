Public Class CharacterTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, ICharacter))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ICharacter = New Character(worldData.Object, id)
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
    Sub ShouldAttempToDeterineEnemyPresenceForACharacterFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(It.IsAny(Of Long)))
                subject.CanFight.ShouldBeFalse
                worldData.Verify(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAttemptToReadNameForACharacterFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.Character.ReadName(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveEnemiesAtTheSameLocation()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(It.IsAny(Of Long)))
                subject.Enemies.ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAccessToTheCharacterNavigationSubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Navigation.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAccessToTheCharacterStatisticsSubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Statistics.ShouldNotBeNull
            End Sub)
    End Sub
End Class
