Public Class Item
    Inherits BaseThingie
    Implements IItem

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Sub Destroy() Implements IItem.Destroy
        WorldData.Item.Clear(Id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IItem
        Return If(id.HasValue, New Item(worldData, id.Value), Nothing)
    End Function
End Class
