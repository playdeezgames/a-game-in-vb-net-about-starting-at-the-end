Public Interface ICharacterInventory
    ReadOnly Property HasItems As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem))
    Function ItemsOfItemType(itemType As IItemType) As IEnumerable(Of IItem)
    Sub DropItemsOfItemType(itemType As IItemType)
    Sub TakeItemsOfItemType(itemType As IItemType)
End Interface
