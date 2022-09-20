Public Interface ICharacterStatistics
    ReadOnly Property Satiety As (Long, Long)
    ReadOnly Property Health As (Long, Long)
    ReadOnly Property Attack As Long
    ReadOnly Property Defend As Long
    ReadOnly Property IsDead() As Boolean
    Property Wounds As Long
End Interface
