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
    <Fact>
    Sub ShouldGiveAccessToTheCharacterInventorySubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Inventory.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAccessToTheWorldInWhichAGivenCharacterExists()
        WithSubject(
            Sub(worldData, id, subject)
                subject.World.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCheckForTheExistenceOfEquipmentForAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterEquippedItem.CountForCharacter(It.IsAny(Of Long)))
                subject.HasEquipment.ShouldBeFalse
                worldData.Verify(Function(x) x.CharacterEquippedItem.CountForCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadTheCurrentlyOccupiedEquipSlotsOfAGivenCharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterEquippedItem.ReadForCharacter(It.IsAny(Of Long)))
                subject.EquippedItems.ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterEquippedItem.ReadForCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldDestroyACharacter()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterItem.ReadForCharacter(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.CharacterEquippedItem.ClearForCharacter(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.CharacterStatistic.ClearForCharacter(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.Inventory.ClearForCharacter(It.IsAny(Of Long)))
                subject.Destroy()
                worldData.Verify(Function(x) x.CharacterItem.ReadForCharacter(id))
                worldData.Verify(Sub(x) x.CharacterEquippedItem.ClearForCharacter(id))
                worldData.Verify(Sub(x) x.CharacterStatistic.ClearForCharacter(id))
                worldData.Verify(Sub(x) x.Inventory.ClearForCharacter(id))
            End Sub)
    End Sub
End Class
