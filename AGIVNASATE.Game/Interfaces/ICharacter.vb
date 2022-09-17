Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Location As ILocation
    Sub Move(route As IRoute)
End Interface
