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
    Sub ShouldAttempToReadLocationForACharacterFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Character).Returns((New Mock(Of ICharacterData)).Object)
                subject.Location.ShouldBeNull
                worldData.Verify(Function(x) x.Character.ReadLocation(id))
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
End Class
