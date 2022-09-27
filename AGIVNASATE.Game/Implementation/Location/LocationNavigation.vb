Public Class LocationNavigation
    Inherits BaseThingie
    Implements ILocationNavigation
    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub
    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ILocationNavigation
        Return If(id.HasValue, New LocationNavigation(worldData, id.Value), Nothing)
    End Function

    Public Sub CreateRoute(routeType As IRouteType, routeName As String, toLocation As ILocation) Implements ILocationNavigation.CreateRoute
        WorldData.Route.Create(routeType.Id, routeName, Id, toLocation.Id)
    End Sub

    Public ReadOnly Property HasRoutes As Boolean Implements ILocationNavigation.HasRoutes
        Get
            Return WorldData.Route.CountForFromLocation(Id) > 0
        End Get
    End Property
    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocationNavigation.Routes
        Get
            Return WorldData.Route.ReadForFromLocation(Id).Select(Function(x) Route.FromId(WorldData, x))
        End Get
    End Property
End Class
