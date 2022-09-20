Module CounterAttackProcessor
    Friend Sub Run(character As ICharacter)
        Dim enemies = character.Combat.Enemies
        For Each enemy In enemies
            AttackProcessor.Run(enemy, character)
            If character.Statistics.IsDead Then
                Return
            End If
        Next
    End Sub
End Module
