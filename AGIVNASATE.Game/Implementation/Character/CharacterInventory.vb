﻿Public Class CharacterInventory
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
        Throw New NotImplementedException()
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
