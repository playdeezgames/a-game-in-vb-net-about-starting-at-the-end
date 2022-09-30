Public Class ItemNameData
    Inherits BaseData
    Implements IItemNameData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function Read(itemId As Long) As String Implements IItemNameData.Read
        Return Nothing
    End Function
End Class
