Public Interface ILocationNavigation
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Sub CreateRoute(routeName As String, toLocation As ILocation)
End Interface
