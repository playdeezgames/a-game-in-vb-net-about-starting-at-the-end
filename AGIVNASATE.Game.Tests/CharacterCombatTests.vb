Public Class CharacterCombatTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, ICharacterCombat))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ICharacterCombat = New CharacterCombat(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
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
End Class
