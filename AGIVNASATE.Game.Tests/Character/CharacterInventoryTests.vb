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
    <Fact>
    Sub ShouldRetrieveItemsOfAGivenItemTypeFromAGivenCharactersInventory()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                worldData.Setup(Function(x) x.CharacterItem.ReadForItemType(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.ItemsOfItemType(ItemType.FromId(worldData.Object, itemTypeId)).ShouldBeEmpty
                worldData.Verify(Function(x) x.CharacterItem.ReadForItemType(id, itemTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldDropAllItemsOfAGivenTypeOntoTheFloor()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                Const itemId = 3L
                Const locationId = 4L
                worldData.Setup(Function(x) x.CharacterItem.ReadForItemType(It.IsAny(Of Long), It.IsAny(Of Long))).Returns(New List(Of Long) From {itemId})
                worldData.Setup(Function(x) x.Character.ReadLocation(id)).Returns(locationId)
                worldData.Setup(Function(x) x.Inventory.ReadForLocation(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.InventoryItem.Write(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.DropItemsOfItemType(ItemType.FromId(worldData.Object, itemTypeId))
                worldData.Verify(Function(x) x.Character.ReadLocation(id))
                worldData.Verify(Function(x) x.CharacterItem.ReadForItemType(id, itemTypeId))
                worldData.Verify(Function(x) x.Inventory.ReadForLocation(locationId))
                worldData.Verify(Function(x) x.Inventory.CreateForLocation(locationId))
                worldData.Verify(Sub(x) x.InventoryItem.Write(itemId, 0))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldTakeTheItemsOfAGivenItemTypeFromTheLocationWhereAGivenCharacterExists()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                Const locationId = 3L
                Const itemId = 4L
                worldData.Setup(Function(x) x.LocationItem.ReadForItemType(It.IsAny(Of Long), It.IsAny(Of Long))).Returns(New List(Of Long) From {itemId})
                worldData.Setup(Function(x) x.Character.ReadLocation(It.IsAny(Of Long))).Returns(locationId)
                worldData.Setup(Function(x) x.Inventory.ReadForCharacter(It.IsAny(Of Long)))
                worldData.Setup(Function(x) x.Inventory.CreateForCharacter(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.InventoryItem.Write(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.TakeItemsOfItemType(ItemType.FromId(worldData.Object, itemTypeId))
                worldData.Verify(Function(x) x.Character.ReadLocation(id))
                worldData.Verify(Function(x) x.LocationItem.ReadForItemType(locationId, itemTypeId))
                worldData.Verify(Function(x) x.Inventory.ReadForCharacter(id))
                worldData.Verify(Function(x) x.Inventory.CreateForCharacter(id))
                worldData.Verify(Sub(x) x.InventoryItem.Write(itemId, 0))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRunTheUseEventAssociatedWithAGivenItemType()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                worldData.Setup(Function(x) x.ItemType.ReadUseEventName(It.IsAny(Of Long)))
                worldData.Setup(Sub(x) x.Events.Raise(It.IsAny(Of String), It.IsAny(Of Long)))
                subject.UseItemOfItemType(ItemType.FromId(worldData.Object, itemTypeId)).ShouldBeNull
                worldData.Verify(Function(x) x.ItemType.ReadUseEventName(itemTypeId))
                worldData.Verify(Sub(x) x.Events.Raise(Nothing, id, itemTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldFetchAnItemOfAGivenItemTypeFromAGivenCharactersInventory()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                worldData.Setup(Function(x) x.CharacterItem.ReadForItemType(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.ItemOfItemType(ItemType.FromId(worldData.Object, itemTypeId)).ShouldBeNull
                worldData.Verify(Function(x) x.CharacterItem.ReadForItemType(id, itemTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldEquipAnItemOfAGivenItemTypeFromAGivenCharactersInventory()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemTypeId = 2L
                worldData.Setup(Function(x) x.ItemTypeEquipSlot.CountForItemType(It.IsAny(Of Long)))
                subject.EquipItemOfItemType(ItemType.FromId(worldData.Object, itemTypeId))
                worldData.Verify(Function(x) x.ItemTypeEquipSlot.CountForItemType(itemTypeId))
            End Sub)
    End Sub
End Class
