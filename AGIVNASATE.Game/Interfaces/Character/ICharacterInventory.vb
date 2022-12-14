Public Interface ICharacterInventory
    ReadOnly Property HasItems As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem))
    Function ItemOfItemType(itemType As IItemType) As IItem
    Function ItemsOfItemType(itemType As IItemType) As IEnumerable(Of IItem)
    Sub DropItemsOfItemType(itemType As IItemType)
    Sub TakeItemsOfItemType(itemType As IItemType)
    Function UseItemOfItemType(itemType As IItemType) As String
    Sub EquipItemOfItemType(itemType As IItemType)
End Interface
