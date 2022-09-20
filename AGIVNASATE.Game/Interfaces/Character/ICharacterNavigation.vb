Public Interface ICharacterNavigation
    ReadOnly Property Location As ILocation
    Sub Move(route As IRoute)
End Interface
