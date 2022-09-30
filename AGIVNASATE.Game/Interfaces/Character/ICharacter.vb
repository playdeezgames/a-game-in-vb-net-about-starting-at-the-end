Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics
    ReadOnly Property Combat As ICharacterCombat
    ReadOnly Property Inventory As ICharacterInventory
    Sub Destroy()
    ReadOnly Property World As IWorld
    ReadOnly Property HasEquipment As Boolean
    ReadOnly Property EquippedItems As IReadOnlyDictionary(Of IEquipSlot, IItem)
End Interface
