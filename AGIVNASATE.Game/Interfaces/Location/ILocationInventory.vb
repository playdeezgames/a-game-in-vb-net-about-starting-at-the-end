Public Interface ILocationInventory
    Inherits IBaseThingie
    Sub AddItem(item As IItem)
    Function HasItems() As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem))
    Function ItemsOfItemType(itemType As IItemType) As IEnumerable(Of IItem)
End Interface
