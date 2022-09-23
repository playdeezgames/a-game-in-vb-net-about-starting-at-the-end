Public Interface IInventoryData
    Function ReadForLocation(locationId As Long) As Long?
    Function CreateForLocation(locationId As Long) As Long
End Interface
