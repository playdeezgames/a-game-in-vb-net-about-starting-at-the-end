Public Interface ICharacterInventory
    ReadOnly Property HasInventory As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem))
End Interface
