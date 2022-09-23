Public Class LocationData
    Inherits BaseData
    Implements ILocationData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadName(locationId As Long) As String Implements ILocationData.ReadName
        Return Store.ReadColumnString(Of Long)(
            AddressOf NoInitializer,
            Tables.Locations,
            Columns.LocationNameColumn,
            (Columns.LocationIdColumn, locationId))
    End Function
End Class
