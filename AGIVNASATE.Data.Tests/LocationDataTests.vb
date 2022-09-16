Public Class LocationDataTests
    Private Sub WithLocationData(stuffToDo As Action(Of Mock(Of IStore), Long, ILocationData))
        Const id = 1L
        Dim store As New Mock(Of IStore)
        Dim subject As ILocationData = New LocationData(store.Object)
        stuffToDo(store, id, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptReadingTheNameOfALocationFromTheStore()
        WithLocationData(
            Sub(store, id, subject)
                subject.ReadName(id).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Tables.Locations,
                        Columns.LocationNameColumn,
                        (Columns.LocationIdColumn, id)))
            End Sub)
    End Sub
End Class
