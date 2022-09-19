Public Interface ILocation
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property HasRoutes As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property Navigation As ILocationNavigation
End Interface
