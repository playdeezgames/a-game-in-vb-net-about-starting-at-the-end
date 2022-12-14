Public Class CharacterInventory
    Inherits BaseThingie
    Implements ICharacterInventory

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacterInventory
        Return If(id.HasValue, New CharacterInventory(worldData, id.Value), Nothing)
    End Function

    Public Function ItemsOfItemType(itemType As IItemType) As IEnumerable(Of IItem) Implements ICharacterInventory.ItemsOfItemType
        Return WorldData.CharacterItem.ReadForItemType(Id, itemType.Id).Select(Function(x) Item.FromId(WorldData, x))
    End Function

    Public Sub DropItemsOfItemType(itemType As IItemType) Implements ICharacterInventory.DropItemsOfItemType
        Dim itemsToDrop = ItemsOfItemType(itemType)
        For Each itemToDrop In itemsToDrop
            DropItem(itemToDrop)
        Next
    End Sub

    Private Sub DropItem(itemToDrop As IItem)
        CharacterNavigation.FromId(WorldData, Id).Location.Inventory.AddItem(itemToDrop)
    End Sub

    Public Sub TakeItemsOfItemType(itemType As IItemType) Implements ICharacterInventory.TakeItemsOfItemType
        Dim itemsToTake = CharacterNavigation.FromId(WorldData, Id).Location.Inventory.ItemsOfItemType(itemType)
        For Each itemToTake In itemsToTake
            AddItem(itemToTake)
        Next
    End Sub

    Private Sub AddItem(item As IItem)
        Dim inventoryId As Long? = WorldData.Inventory.ReadForCharacter(Id)
        If Not inventoryId.HasValue Then
            inventoryId = WorldData.Inventory.CreateForCharacter(Id)
        End If
        WorldData.InventoryItem.Write(item.Id, inventoryId.Value)
    End Sub

    Public Function UseItemOfItemType(itemType As IItemType) As String Implements ICharacterInventory.UseItemOfItemType
        Dim useEventName = WorldData.ItemType.ReadUseEventName(itemType.Id)
        Return WorldData.Events.Raise(useEventName, Id, itemType.Id)
    End Function

    Public Function ItemOfItemType(itemType As IItemType) As IItem Implements ICharacterInventory.ItemOfItemType
        Dim itemsIds = WorldData.CharacterItem.ReadForItemType(Id, itemType.Id)
        If itemsIds.Any Then
            Return Item.FromId(WorldData, itemsIds.First)
        End If
        Return Nothing
    End Function

    Public Sub EquipItemOfItemType(itemType As IItemType) Implements ICharacterInventory.EquipItemOfItemType
        If Not itemType.CanEquip Then
            Return
        End If
        Dim items = ItemsOfItemType(itemType)
        If Not items.Any Then
            Return
        End If
        Dim item = items.First
        Dim equipSlots = itemType.EquipSlots
        'TODO: unequip whatever item is already there!
        WorldData.InventoryItem.ClearForItem(item.Id)
        For Each equipSlot In equipSlots
            WorldData.CharacterEquippedItem.Write(Id, equipSlot.Id, item.Id)
        Next
    End Sub

    Public ReadOnly Property HasItems As Boolean Implements ICharacterInventory.HasItems
        Get
            Return WorldData.CharacterItem.ReadCountForCharacter(Id) > 0L
        End Get
    End Property

    Public ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem)) Implements ICharacterInventory.ItemStacks
        Get
            Return WorldData.CharacterItem.ReadForCharacter(Id).
                GroupBy(Function(x) x.Item2).
                ToDictionary(Function(x) ItemType.FromId(WorldData, x.Key),
                             Function(x) x.Select(Function(y) Item.FromId(WorldData, y.Item1)))
        End Get
    End Property
End Class
