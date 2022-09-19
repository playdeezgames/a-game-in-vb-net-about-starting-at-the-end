Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics

    ReadOnly Property CanFight As Boolean
    ReadOnly Property Enemies As IEnumerable(Of ICharacter)
End Interface
