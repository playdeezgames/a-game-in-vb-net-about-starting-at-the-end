Public Class ItemTypeEquipSlotDataTests
    Private Sub WithItemTypeEquipSlotData(stuffToDo As Action(Of Mock(Of IStore), IItemTypeEquipSlotData))
        Dim store As New Mock(Of IStore)
        Dim subject As IItemTypeEquipSlotData = New ItemTypeEquipSlotData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldAttemptToReadTheCanEquipFlagForAGivenItemTypeFromTheStore()
        WithItemTypeEquipSlotData(
            Sub(store, subject)
                Const itemTypeId = 1L
                subject.ReadCanEquip(itemTypeId).ShouldBe(0)
                store.Verify(
                    Function(x) x.ReadCountForColumnValue(
                        It.IsAny(Of Action),
                        Tables.ItemTypeEquipSlots,
                        (Columns.ItemTypeIdColumn, itemTypeId)))
            End Sub)
    End Sub
End Class
