Public Class ItemTypeData
    Inherits BaseData
    Implements IItemTypeData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadName(itemTypeId As Long) As String Implements IItemTypeData.ReadName
        Return Store.ReadColumnString(
            AddressOf NoInitializer,
            Tables.ItemTypes,
            Columns.ItemTypeNameColumn,
            (Columns.ItemTypeIdColumn, itemTypeId))
    End Function

    Public Function ReadUseEventName(itemTypeId As Long) As String Implements IItemTypeData.ReadUseEventName
        Return Store.ReadColumnString(
            AddressOf NoInitializer,
            Tables.ItemTypes,
            Columns.UseEventNameColumn,
            (Columns.ItemTypeIdColumn, itemTypeId))
    End Function
End Class
