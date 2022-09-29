Public Class EquipSlot
    Inherits BaseThingie
    Implements IEquipSlot

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IEquipSlot
        Return If(id.HasValue, New EquipSlot(worldData, id.Value), Nothing)
    End Function
End Class
