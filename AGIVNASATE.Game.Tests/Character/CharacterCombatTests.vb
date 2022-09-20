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
                Dim enemy As New Mock(Of ICharacter)
                Dim actual = subject.Attack(enemy.Object)
                actual.Item1.ShouldBe(0)
                actual.Item2.ShouldBeTrue
                enemy.VerifyNoOtherCalls()
            End Sub)
    End Sub
End Class
