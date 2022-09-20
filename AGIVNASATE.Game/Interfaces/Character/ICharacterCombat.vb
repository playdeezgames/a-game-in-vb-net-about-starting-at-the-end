Public Interface ICharacterCombat
    ReadOnly Property CanFight As Boolean
    ReadOnly Property Enemies As IEnumerable(Of ICharacter)
    Function Attack(defender As ICharacter) As (Long, Boolean)
    ReadOnly Property Statistics As ICharacterStatistics
    Sub DoDamage(damage As Long)
End Interface
