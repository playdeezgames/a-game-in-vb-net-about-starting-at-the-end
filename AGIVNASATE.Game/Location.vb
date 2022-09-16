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
End Class
