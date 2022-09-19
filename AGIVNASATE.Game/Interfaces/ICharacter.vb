Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics
    ReadOnly Property Combat As ICharacterCombat
End Interface
