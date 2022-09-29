Public Class EquipSlotData
    Inherits BaseData
    Implements IEquipSlotData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadName(equipSlotId As Long) As String Implements IEquipSlotData.ReadName
        Return Store.ReadColumnString(
            AddressOf NoInitializer,
            Tables.EquipSlots,
            Columns.EquipSlotNameColumn,
            (Columns.EquipSlotIdColumn, equipSlotId))
    End Function
End Class
