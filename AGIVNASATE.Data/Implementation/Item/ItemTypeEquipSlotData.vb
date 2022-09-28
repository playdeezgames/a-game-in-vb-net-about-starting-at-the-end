Public Class ItemTypeEquipSlotData
    Inherits BaseData
    Implements IItemTypeEquipSlotData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadCanEquip(itemTypeId As Long) As Long Implements IItemTypeEquipSlotData.ReadCanEquip
        Return Store.ReadCountForColumnValue(
            AddressOf NoInitializer,
            Tables.ItemTypeEquipSlots,
            (Columns.ItemTypeIdColumn, itemTypeId))
    End Function
End Class
