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
    Sub ShouldRetrieveTheSatietyStatisticsForAGiveCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Satiety
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 1L))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 2L))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheHealthStatisticsForAGiveCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Health
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 3L))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 4L))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheAttackStatisticForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Attack
                actual.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 5L))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveTheDefendStatisticForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim actual = subject.Defend
                actual.ShouldBe(0)
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 6L))
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
End Class
