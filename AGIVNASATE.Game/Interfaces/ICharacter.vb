Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Navigation As ICharacterNavigation

    ReadOnly Property Satiety As (Long, Long)
    ReadOnly Property Health As (Long, Long)
    ReadOnly Property Attack As Long
    ReadOnly Property Defend As Long

    ReadOnly Property CanFight As Boolean
    ReadOnly Property Enemies As IEnumerable(Of ICharacter)
End Interface
