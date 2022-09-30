Public Class Item
    Inherits BaseThingie
    Implements IItem

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public ReadOnly Property Name As String Implements IItem.Name
        Get
            Return WorldData.ItemName.Read(Id)
        End Get
    End Property

    Public Sub Destroy() Implements IItem.Destroy
        WorldData.Item.Clear(Id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IItem
        Return If(id.HasValue, New Item(worldData, id.Value), Nothing)
    End Function
End Class
