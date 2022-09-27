Public Class RouteData
    Inherits BaseData
    Implements IRouteData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function CountForFromLocation(fromLocationId As Long) As Long Implements IRouteData.CountForFromLocation
        Return Store.ReadCountForColumnValue(AddressOf NoInitializer, Tables.Routes, (Columns.FromLocationIdColumn, fromLocationId))
    End Function

    Public Function ReadName(routeId As Long) As String Implements IRouteData.ReadName
        Return Store.ReadColumnString(Of Long)(
            AddressOf NoInitializer,
            Tables.Routes,
            Columns.RouteNameColumn,
            (Columns.RouteIdColumn, routeId))
    End Function

    Public Function ReadForFromLocation(fromLocationId As Long) As IEnumerable(Of Long) Implements IRouteData.ReadForFromLocation
        Return Store.ReadRecordsWithColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Routes,
            Columns.RouteIdColumn,
            (Columns.FromLocationIdColumn, fromLocationId))
    End Function

    Public Function ReadToLocation(routeId As Long) As Long? Implements IRouteData.ReadToLocation
        Return Store.ReadColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Routes,
            Columns.ToLocationIdColumn,
            (Columns.RouteIdColumn, routeId))
    End Function

    Public Function Create(routeTypeId As Long, routeName As String, fromLocationId As Long, toLocationId As Long) As Long Implements IRouteData.Create
        Return Store.CreateRecord(
            AddressOf NoInitializer,
            Tables.Routes,
            (Columns.RouteTypeIdColumn, routeTypeId),
            (Columns.RouteNameColumn, routeName),
            (Columns.FromLocationIdColumn, fromLocationId),
            (Columns.ToLocationIdColumn, toLocationId))
    End Function
End Class
