Public Interface IRouteData
    Function CountForFromLocation(fromLocationId As Long) As Long
    Function ReadName(routeId As Long) As String
    Function ReadForFromLocation(fromLocationId As Long) As IEnumerable(Of Long)
End Interface
