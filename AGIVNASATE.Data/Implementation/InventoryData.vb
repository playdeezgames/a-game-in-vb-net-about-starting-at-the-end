Public Class InventoryData
    Inherits BaseData
    Implements IInventoryData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadForLocation(locationId As Long) As Long? Implements IInventoryData.ReadForLocation
        Return Store.ReadColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Inventories,
            Columns.InventoryIdColumn,
            (Columns.LocationIdColumn, locationId))
    End Function

    Public Function CreateForLocation(locationId As Long) As Long Implements IInventoryData.CreateForLocation
        Return Store.CreateRecord(
            AddressOf NoInitializer,
            Tables.Inventories,
            (Columns.LocationIdColumn, locationId))
    End Function
End Class
