Public Interface IWorld
    ReadOnly Property PlayerCharacter As ICharacter
    ReadOnly Property StartLocation As ILocation
    Sub Save(filename As String)
    ReadOnly Property RouteTypes(routeTypeId As Long) As IRouteType
End Interface
