Public Class RouteType
    Inherits BaseThingie
    Implements IRouteType

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, routeTypeId As Long?) As IRouteType
        Return If(routeTypeId.HasValue, New RouteType(worldData, routeTypeId.Value), Nothing)
    End Function
End Class
