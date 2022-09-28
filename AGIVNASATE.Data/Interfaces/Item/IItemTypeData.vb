Public Interface IItemTypeData
    Function ReadName(itemTypeId As Long) As String
    Function ReadUseEventName(itemTypeId As Long) As String
    Function ReadCanEquip(itemTypeId As Long) As Long?
End Interface
