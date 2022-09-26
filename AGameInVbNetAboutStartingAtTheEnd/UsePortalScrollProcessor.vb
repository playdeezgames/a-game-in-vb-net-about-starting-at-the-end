Module UsePortalScrollProcessor
    Friend Function Run(character As ICharacter, itemType As IItemType) As String
        Dim item As IItem = character.Inventory.ItemOfItemType(itemType)
        If item Is Nothing Then
            Return $"{character.Name} has no {itemType.Name}."
        End If
        Dim startLocation As ILocation = character.World.StartLocation
        'TODO: where is the start location?
        'TODO: make route from current location to start location
        'TODO: make route from start location to current location
        item.Destroy()
        Return $"{character.Name} uses the {itemType.Name}."
    End Function
End Module
