Public Class ItemData
    Inherits BaseData
    Implements IItemData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub Clear(itemId As Long) Implements IItemData.Clear
        Store.ClearForColumnValue(
            AddressOf NoInitializer,
            Tables.InventoryItems,
            (Columns.ItemIdColumn, itemId))
        Store.ClearForColumnValue(
            AddressOf NoInitializer,
            Tables.Items,
            (Columns.ItemIdColumn, itemId))
    End Sub
End Class
