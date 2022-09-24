Public Class LocationItemData
    Inherits BaseData
    Implements ILocationItemData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadCountForLocation(locationId As Long) As Long Implements ILocationItemData.ReadCountForLocation
        Return Store.ReadCountForColumnValue(
            AddressOf NoInitializer,
            Views.LocationItems,
            (Columns.LocationIdColumn, locationId))
    End Function

    Public Function ReadForLocation(locationId As Long) As IEnumerable(Of Tuple(Of Long, Long)) Implements ILocationItemData.ReadForLocation
        Return Array.Empty(Of Tuple(Of Long, Long))
    End Function
End Class
