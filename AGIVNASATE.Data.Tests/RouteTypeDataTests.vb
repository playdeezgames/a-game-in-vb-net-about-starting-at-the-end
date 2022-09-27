Public Class RouteTypeDataTests
    Private Sub WithRouteTypeData(stuffToDo As Action(Of Mock(Of IStore), IRouteTypeData))
        Dim store As New Mock(Of IStore)
        Dim subject As IRouteTypeData = New RouteTypeData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheUseEventNameFromTheDataStore()
        WithRouteTypeData(
            Sub(store, subject)
                Const routeTypeId = 1L
                subject.ReadUseEventName(routeTypeId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Tables.RouteTypes,
                        Columns.UseEventNameColumn,
                        (Columns.RouteTypeIdColumn, routeTypeId)))
            End Sub)
    End Sub
End Class
