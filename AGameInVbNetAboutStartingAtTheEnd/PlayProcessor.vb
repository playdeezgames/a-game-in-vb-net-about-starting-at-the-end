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
                    Dim characterHealth = character.Health
                    AnsiConsole.MarkupLine($"* {character.Name} ({characterHealth.Item1}/{characterHealth.Item2})")
                Next
            End If
            AnsiConsole.MarkupLine("Statistics:")
            Dim satiety = playerCharacter.Satiety
            AnsiConsole.MarkupLine($"* Satiety: {satiety.Item1}/{satiety.Item2}")
            Dim health = playerCharacter.Health
            AnsiConsole.MarkupLine($"* Health: {health.Item1}/{health.Item2}")
            AnsiConsole.MarkupLine($"* Attack: {playerCharacter.Attack}")
            AnsiConsole.MarkupLine($"* Defend: {playerCharacter.Defend}")
            If location.HasRoutes Then
                AnsiConsole.MarkupLine("Routes:")
                For Each route In location.Routes
                    AnsiConsole.MarkupLine($"* {route.Name}")
                Next
            End If
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If playerCharacter.CanFight Then
                prompt.AddChoice(FightText)
            End If
            If location.HasRoutes Then
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
        End While
    End Sub
End Module
