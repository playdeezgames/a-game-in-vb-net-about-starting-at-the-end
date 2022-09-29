Module PlayProcessor
    Friend Sub Run(world As IWorld)
        Dim done = False
        While Not done
            world.Save("quicksave.db")
            AnsiConsole.Clear()
            Dim playerCharacter = world.PlayerCharacter
            Dim location = playerCharacter.Navigation.Location
            AnsiConsole.MarkupLine($"{CharacterAndHealth(playerCharacter)} is at {location.Name}.")

            Dim characters = location.Characters.Where(Function(x) x.Id <> playerCharacter.Id)
            If characters.Any Then
                AnsiConsole.Markup($"Other Characters: ")
                AnsiConsole.MarkupLine(String.Join(", ", characters.Select(AddressOf CharacterAndHealth)))
            End If

            If location.Navigation.HasRoutes Then
                AnsiConsole.Markup("Exits:")
                AnsiConsole.MarkupLine(String.Join(", ", location.Navigation.Routes.Select(Function(x) x.Name)))
            End If

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If playerCharacter.Combat.CanFight Then
                prompt.AddChoice(FightText)
            End If
            If location.Navigation.HasRoutes Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(StatisticsText)
            If playerCharacter.Inventory.HasItems Then
                prompt.AddChoice(InventoryText)
            End If
            If playerCharacter.Navigation.Location.Inventory.HasItems Then
                prompt.AddChoice(GroundText)
            End If
            If playerCharacter.HasEquipment Then
                prompt.AddChoice(EquipmentText)
            End If
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = Confirm("Are you sure you want to abandon the game?")
                Case FightText
                    FightProcessor.Run(playerCharacter)
                Case GroundText
                    GroundProcessor.Run(playerCharacter)
                Case InventoryText
                    InventoryProcessor.Run(playerCharacter)
                Case MoveText
                    MoveProcessor.Run(playerCharacter)
                Case StatisticsText
                    StatisticsProcessor.Run(playerCharacter)
            End Select
            done = done OrElse playerCharacter.Statistics.IsDead
        End While
    End Sub
End Module
