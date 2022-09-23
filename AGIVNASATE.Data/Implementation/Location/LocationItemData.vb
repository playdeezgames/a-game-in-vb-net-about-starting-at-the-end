Public Class LocationItemData
    Inherits BaseData
    Implements ILocationItemData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadCountForLocation(locationId As Long) As Long Implements ILocationItemData.ReadCountForLocation
        Return 0
    End Function
End Class
