Public Interface IItemType
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property CanUse As Boolean
    ReadOnly Property CanEquip As Boolean
    ReadOnly Property EquipSlots As IEnumerable(Of IEquipSlot)
End Interface
