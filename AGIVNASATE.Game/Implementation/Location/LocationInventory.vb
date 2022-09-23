Public Class LocationInventory
    Inherits BaseThingie
    Implements ILocationInventory

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Sub AddItem(item As IItem) Implements ILocationInventory.AddItem
        Dim inventoryId As Long? = WorldData.Inventory.ReadForLocation(Id)
        If Not inventoryId.HasValue Then
            inventoryId = WorldData.Inventory.CreateForLocation(Id)
        End If
        WorldData.InventoryItem.Write(item.Id, inventoryId.Value)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ILocationInventory
        Return If(id.HasValue, New LocationInventory(worldData, id.Value), Nothing)
    End Function
End Class
