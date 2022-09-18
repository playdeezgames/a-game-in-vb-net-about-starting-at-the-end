Public Interface ICharacter
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Location As ILocation
    Sub Move(route As IRoute)
    ReadOnly Property Satiety As (Long, Long)
    ReadOnly Property Health As (Long, Long)
End Interface
