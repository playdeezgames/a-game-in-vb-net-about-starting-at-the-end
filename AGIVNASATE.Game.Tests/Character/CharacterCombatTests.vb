Public Class CharacterCombatTests
    Inherits BaseGameTests(Of ICharacterCombat)
    Public Sub New()
        MyBase.New(AddressOf CharacterCombat.FromId)
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
    Sub ShouldRetrieveEnemiesAtTheSameLocation()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(It.IsAny(Of Long)))
                subject.Enemies.ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldAllowAttackingOfAnotherCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                Const enemyId = 2L
                worldData.Setup(Function(x) x.CharacterStatistic.Read(It.IsAny(Of Long), It.IsAny(Of Long)))
                Dim enemy = Character.FromId(worldData.Object, enemyId)
                Dim actual = subject.Attack(enemy)
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBeTrue
                worldData.Verify(Function(x) x.CharacterStatistic.Read(id, 5))
                worldData.Verify(Function(x) x.CharacterStatistic.Read(enemyId, 6))
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
    Sub ShouldAddWoundsToACharacter()
        WithSubject(
            Sub(worldData, id, subject)
                Const damage = 2L
                subject.DoDamage(damage)
            End Sub)
    End Sub
End Class
