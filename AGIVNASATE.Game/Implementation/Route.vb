Public Class Route
    Inherits BaseThingie
    Implements IRoute

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public ReadOnly Property Name As String Implements IRoute.Name
        Get
            Return WorldData.Route.ReadName(Id)
        End Get
    End Property

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IRoute
        Return If(id.HasValue, New Route(worldData, id.Value), Nothing)
    End Function
End Class
