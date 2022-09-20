Public Interface ILocationNavigation
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
End Interface
