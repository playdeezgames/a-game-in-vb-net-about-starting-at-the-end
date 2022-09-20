Module PlayProcessor
    Friend Sub Run(world As IWorld)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim playerCharacter = world.PlayerCharacter
            Dim location = playerCharacter.Navigation.Location
            AnsiConsole.MarkupLine($"{playerCharacter.Name} is at {location.Name}.")
            Dim characters = location.Characters.Where(Function(x) x.Id <> playerCharacter.Id)
            If characters.Any Then
                AnsiConsole.MarkupLine($"Other Characters:")
                For Each character In characters
                    Dim characterHealth = character.Statistics.Health
                    AnsiConsole.MarkupLine($"* {character.Name} ({characterHealth.Item1}/{characterHealth.Item2})")
                Next
            End If
            AnsiConsole.MarkupLine("Statistics:")
            Dim satiety = playerCharacter.Statistics.Satiety
            AnsiConsole.MarkupLine($"* Satiety: {satiety.Item1}/{satiety.Item2}")
            Dim health = playerCharacter.Statistics.Health
            AnsiConsole.MarkupLine($"* Health: {health.Item1}/{health.Item2}")
            AnsiConsole.MarkupLine($"* Attack: {playerCharacter.Statistics.Attack}")
            AnsiConsole.MarkupLine($"* Defend: {playerCharacter.Statistics.Defend}")
            If location.Navigation.HasRoutes Then
                AnsiConsole.MarkupLine("Routes:")
                For Each route In location.Navigation.Routes
                    AnsiConsole.MarkupLine($"* {route.Name}")
                Next
            End If
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If playerCharacter.Combat.CanFight Then
                prompt.AddChoice(FightText)
            End If
            If location.Navigation.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = Confirm("Are you sure you want to abandon the game?")
                Case FightText
                    FightProcessor.Run(playerCharacter)
                Case MoveText
                    MoveProcessor.Run(playerCharacter)
            End Select
            done = playerCharacter.Statistics.IsDead
        End While
    End Sub
End Module
