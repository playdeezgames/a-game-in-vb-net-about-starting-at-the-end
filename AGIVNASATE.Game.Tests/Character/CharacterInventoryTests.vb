Public Class CharacterInventoryTests
    Inherits BaseGameTests(Of ICharacterInventory)
    Public Sub New()
        MyBase.New(AddressOf CharacterInventory.FromId)
    End Sub
    <Fact>
    Sub ShouldCreateACharacterInventoryObject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCheckForThePresenceOfItemsInTheCharactersInventory()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterItem.ReadCountForCharacter(It.IsAny(Of Long)))
                subject.HasItems.ShouldBeFalse
                worldData.Verify(Function(x) x.CharacterItem.ReadCountForCharacter(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveCategorizedItemsInTheCharacatersInventory()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.CharacterItem.ReadForCharacter(It.IsAny(Of Long)))
                subject.ItemStacks.ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterItem.ReadForCharacter(id))
            End Sub)
    End Sub
End Class
