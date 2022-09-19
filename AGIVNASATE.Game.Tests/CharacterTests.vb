Public Class CharacterTests
    Inherits BaseGameTests(Of ICharacter)
    Sub New()
        MyBase.New(AddressOf Character.FromId)
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
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
    <Fact>
    Sub ShouldGiveAccessToTheCharacterCombatSubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Combat.ShouldNotBeNull
            End Sub)
    End Sub
End Class
