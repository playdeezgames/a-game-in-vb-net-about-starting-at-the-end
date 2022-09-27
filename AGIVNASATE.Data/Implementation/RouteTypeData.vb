Public Class RouteTypeData
    Inherits BaseData
    Implements IRouteTypeData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadUseEventName(routeTypeId As Long) As String Implements IRouteTypeData.ReadUseEventName
        Return Store.ReadColumnString(AddressOf NoInitializer, Tables.RouteTypes, Columns.UseEventNameColumn, (Columns.RouteTypeIdColumn, routeTypeId))
    End Function
End Class
