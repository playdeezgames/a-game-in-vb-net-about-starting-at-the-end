Public Class ItemType
    Inherits BaseThingie
    Implements IItemType
    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub
    Public ReadOnly Property Name As String Implements IItemType.Name
        Get
            Return WorldData.ItemType.ReadName(Id)
        End Get
    End Property
    Public ReadOnly Property CanUse As Boolean Implements IItemType.CanUse
        Get
            Return Not String.IsNullOrWhiteSpace(WorldData.ItemType.ReadUseEventName(Id))
        End Get
    End Property

    Public ReadOnly Property CanEquip As Boolean Implements IItemType.CanEquip
        Get
            Return WorldData.ItemTypeEquipSlot.CountForItemType(Id) > 0
        End Get
    End Property

    Public ReadOnly Property EquipSlots As IEnumerable(Of IEquipSlot) Implements IItemType.EquipSlots
        Get
            Return WorldData.ItemTypeEquipSlot.ReadForItemType(Id).Select(Function(x) EquipSlot.FromId(WorldData, x))
        End Get
    End Property
    Public Shared Function FromId(worldData As IWorldData, id As Long?) As IItemType
        Return If(id.HasValue, New ItemType(worldData, id.Value), Nothing)
    End Function
End Class
