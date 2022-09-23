Public Class ItemData
    Inherits BaseData
    Implements IInventoryItemData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub Write(itemId As Long, inventoryId As Long) Implements IInventoryItemData.Write
        Store.ReplaceRecord(
            AddressOf NoInitializer,
            Tables.InventoryItems,
            (Columns.InventoryIdColumn, inventoryId),
            (Columns.ItemIdColumn, itemId))
    End Sub
End Class
