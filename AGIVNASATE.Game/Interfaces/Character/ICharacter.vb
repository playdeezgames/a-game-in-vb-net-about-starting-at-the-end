Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics
    ReadOnly Property Combat As ICharacterCombat
    ReadOnly Property Inventory As ICharacterInventory
    ReadOnly Property World As IWorld
End Interface
