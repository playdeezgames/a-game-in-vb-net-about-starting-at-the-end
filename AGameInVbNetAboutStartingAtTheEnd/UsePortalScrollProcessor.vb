Module UsePortalScrollProcessor
    Friend Function Run(character As ICharacter, itemType As IItemType) As String
        Dim item As IItem = character.Inventory.ItemOfItemType(itemType)
        If item Is Nothing Then
            Return $"{character.Name} has no {itemType.Name}."
        End If
        Dim startLocation As ILocation = character.World.StartLocation
        Dim currentLocation = character.Navigation.Location
        startLocation.Navigation.CreateRoute("Portal", currentLocation)
        currentLocation.Navigation.CreateRoute("Portal", startLocation)
        item.Destroy()
        Return $"{character.Name} uses the {itemType.Name}."
    End Function
End Module
