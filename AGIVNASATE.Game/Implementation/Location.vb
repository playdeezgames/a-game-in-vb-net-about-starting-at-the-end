Public Class Location
    Inherits BaseThingie
    Implements ILocation

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ILocation
        Return If(id.HasValue, New Location(worldData, id.Value), Nothing)
    End Function

    Public ReadOnly Property Name As String Implements ILocation.Name
        Get
            Return WorldData.Location.ReadName(Id)
        End Get
    End Property

    Public ReadOnly Property HasRoutes As Boolean Implements ILocation.HasRoutes
        Get
            Return WorldData.Route.CountForFromLocation(Id) > 0
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return WorldData.Route.ReadForFromLocation(Id).Select(Function(x) Route.FromId(WorldData, x))
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Return WorldData.Character.ReadForLocation(Id).Select(Function(x) Character.FromId(WorldData, x))
        End Get
    End Property

    Public ReadOnly Property Navigation As ILocationNavigation Implements ILocation.Navigation
        Get
            Return LocationNavigation.FromId(WorldData, Id)
        End Get
    End Property
End Class
