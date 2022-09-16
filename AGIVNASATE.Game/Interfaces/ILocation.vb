Public Interface ILocation
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
End Interface
