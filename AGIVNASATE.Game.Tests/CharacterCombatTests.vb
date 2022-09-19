Public Class CharacterCombatTests
    Private Sub WithSubject(Of TThingie)(
                                         thingieMaker As Func(Of IWorldData, Long?, TThingie),
                                         stuffToDo As Action(Of Mock(Of IWorldData), Long, TThingie))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As TThingie = thingieMaker(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttempToDeterineEnemyPresenceForACharacterFromTheData()
        WithSubject(
            AddressOf CharacterCombat.FromId,
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(It.IsAny(Of Long)))
                subject.CanFight.ShouldBeFalse
                worldData.Verify(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveEnemiesAtTheSameLocation()
        WithSubject(
            AddressOf CharacterCombat.FromId,
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(It.IsAny(Of Long)))
                subject.Enemies.ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterLocationEsteem.ReadForFromCharacter(id))
            End Sub)
    End Sub
End Class
