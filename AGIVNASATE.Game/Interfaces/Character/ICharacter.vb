Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics
    ReadOnly Property Combat As ICharacterCombat
    ReadOnly Property HasInventory As Boolean
    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem))
End Interface
