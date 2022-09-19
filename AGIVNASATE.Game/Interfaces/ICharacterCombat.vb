Public Interface ICharacterCombat

    ReadOnly Property CanFight As Boolean
    ReadOnly Property Enemies As IEnumerable(Of ICharacter)
End Interface
