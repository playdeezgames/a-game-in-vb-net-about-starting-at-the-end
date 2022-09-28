Public Class ItemTypeDataTests
    Private Sub WithItemTypeData(stuffToDo As Action(Of Mock(Of IStore), IItemTypeData))
        Dim store As New Mock(Of IStore)
        Dim subject As IItemTypeData = New ItemTypeData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheNameOfAnItemTypeOutOfTheDataStore()
        WithItemTypeData(
            Sub(store, subject)
                Const itemTypeId = 1L
                subject.ReadName(itemTypeId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Tables.ItemTypes,
                        Columns.ItemTypeNameColumn,
                        (Columns.ItemTypeIdColumn, itemTypeId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadTheUseEventNameFromTheDataStoreForAGivenItemTypeId()
        WithItemTypeData(
            Sub(store, subject)
                Const itemTypeId = 1L
                subject.ReadUseEventName(itemTypeId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Tables.ItemTypes,
                        Columns.UseEventNameColumn,
                        (Columns.ItemTypeIdColumn, itemTypeId)))
            End Sub)
    End Sub
End Class
