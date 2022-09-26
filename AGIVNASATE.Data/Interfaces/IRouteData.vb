Public Interface IRouteData
    Function CountForFromLocation(fromLocationId As Long) As Long
    Function ReadName(routeId As Long) As String
    Function ReadForFromLocation(fromLocationId As Long) As IEnumerable(Of Long)
    Function ReadToLocation(routeId As Long) As Long?
    Function Create(routeName As String, fromLocationId As Long, toLocationId As Long) As Long
End Interface
