Public Interface ILocationItemData
    Function ReadCountForLocation(locationId As Long) As Long
    Function ReadForLocation(locationId As Long) As IEnumerable(Of Tuple(Of Long, Long))
End Interface
