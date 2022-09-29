Public Interface IItemTypeEquipSlotData
    Function CountForItemType(itemTypeId As Long) As Long
    Function ReadForItemType(itemTypeId As Long) As IEnumerable(Of Long)
End Interface
