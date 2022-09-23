Public Class LocationInventoryTests
    Inherits BaseGameTests(Of ILocationInventory)
    Sub New()
        MyBase.New(AddressOf LocationInventory.FromId)
    End Sub
    <Fact>
    Sub ShouldAddAnItemToTheAssociatedInventoryOfAGivenLocation()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemId = 2L
                Const inventoryId = 3L
                worldData.Setup(Function(x) x.Inventory.ReadForLocation(It.IsAny(Of Long))).Returns(inventoryId)
                worldData.Setup(Sub(x) x.InventoryItem.Write(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.AddItem(Item.FromId(worldData.Object, itemId))
                worldData.Verify(Function(x) x.Inventory.ReadForLocation(id))
                worldData.Verify(Sub(x) x.InventoryItem.Write(itemId, inventoryId))
            End Sub)
    End Sub
End Class
