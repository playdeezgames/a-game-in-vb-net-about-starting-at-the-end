Public Interface IRoute
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property ToLocation As ILocation
    ReadOnly Property RouteType As IRouteType
End Interface
