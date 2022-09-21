Module AttackProcessor
    Friend Sub Run(attacker As ICharacter, defender As ICharacter)
        AnsiConsole.Clear()
        Dim art As String = ""
        If CharacterArt.Images.TryGetValue(attacker.Id, art) Then
            AnsiConsole.MarkupLine(art)
        End If
        AnsiConsole.MarkupLine($"{attacker.Name} attacks {defender.Name}!")
        Dim attackResult = attacker.Combat.Attack(defender)
        AnsiConsole.MarkupLine($"{defender.Name} takes {attackResult.Item1} damage!")
        If attackResult.Item2 Then
            AnsiConsole.MarkupLine($"{attacker.Name} defeats {defender.Name}!")
        End If
        OkPrompt()
    End Sub
End Module
