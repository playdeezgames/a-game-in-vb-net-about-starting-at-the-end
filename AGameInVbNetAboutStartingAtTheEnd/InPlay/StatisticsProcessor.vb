Module StatisticsProcessor
    Friend Sub Run(character As ICharacter)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"Statistics for {character.Name}:")
        Dim satiety = character.Statistics.Satiety
        AnsiConsole.MarkupLine($"* Satiety: {satiety.Item1}/{satiety.Item2}")
        Dim health = character.Statistics.Health
        AnsiConsole.MarkupLine($"* Health: {health.Item1}/{health.Item2}")
        AnsiConsole.MarkupLine($"* Attack: {character.Statistics.Attack}")
        AnsiConsole.MarkupLine($"* Defend: {character.Statistics.Defend}")
        OkPrompt()
    End Sub
End Module
