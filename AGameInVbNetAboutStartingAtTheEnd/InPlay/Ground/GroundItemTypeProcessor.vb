Module GroundItemTypeProcessor
    Friend Sub Run(character As ICharacter, itemType As IItemType)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{itemType.Name}(s) on the ground at {character.Navigation.Location.Name}:[/]"}
            prompt.AddChoice(NeverMindText)
            prompt.AddChoice(TakeAllText)
            Select Case AnsiConsole.Prompt(prompt)
                Case NeverMindText
                    done = True
                Case TakeAllText
                    character.Inventory.TakeItemsOfItemType(itemType)
                    done = True
            End Select
        End While
    End Sub
End Module
