Public Interface IRoute
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property ToLocation As ILocation
    Sub Destroy()
    ReadOnly Property RouteType As IRouteType
End Interface
