Public Class LocationInventory
    Inherits BaseThingie
    Implements ILocationInventory

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem)) Implements ILocationInventory.ItemStacks
        Get
            Return WorldData.LocationItem.ReadForLocation(Id).
                GroupBy(Function(x) x.Item2).
                ToDictionary(Function(x) ItemType.FromId(WorldData, x.Key),
                             Function(x) x.Select(Function(y) Item.FromId(WorldData, y.Item1)))
        End Get
    End Property

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

    Public Function HasItems() As Boolean Implements ILocationInventory.HasItems
        Return WorldData.LocationItem.ReadCountForLocation(Id) > 0L
    End Function
End Class
