Public Class ItemType
    Inherits BaseThingie
    Implements IItemType

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public ReadOnly Property Name As String Implements IItemType.Name
        Get
            Return Nothing
        End Get
    End Property

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IItemType
        Return If(id.HasValue, New ItemType(worldData, id.Value), Nothing)
    End Function
End Class
