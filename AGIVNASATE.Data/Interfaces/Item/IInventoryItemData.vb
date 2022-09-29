Public Interface IInventoryItemData
    Sub Write(itemId As Long, inventoryId As Long)
    Sub ClearForItem(itemId As Long)
End Interface
