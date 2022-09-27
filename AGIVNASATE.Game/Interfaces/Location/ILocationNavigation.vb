Public Interface ILocationNavigation
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Sub CreateRoute(routeType As IRouteType, routeName As String, toLocation As ILocation)
End Interface
