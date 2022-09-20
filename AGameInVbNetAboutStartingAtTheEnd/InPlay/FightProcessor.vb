Module FightProcessor
    Friend Sub Run(character As ICharacter)
        Dim enemy = ChooseEnemy(character.Combat.Enemies)
        If enemy Is Nothing Then
            Return
        End If
        AttackProcessor.Run(character, enemy)
        CounterAttackProcessor.Run(character)
    End Sub
    Private Function ChooseEnemy(enemies As IEnumerable(Of ICharacter)) As ICharacter
        Select Case enemies.Count
            Case 0
                Return Nothing
            Case 1
                Return enemies.Single
            Case Else
                Dim table = enemies.ToDictionary(Function(x) x.Name, Function(x) x)
                Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Enemy?[/]"}
                prompt.AddChoice(NeverMindText)
                prompt.AddChoices(table.Keys)
                Dim answer = AnsiConsole.Prompt(prompt)
                Select Case answer
                    Case NeverMindText
                        Return Nothing
                    Case Else
                        Return table(answer)
                End Select
        End Select
    End Function
End Module
