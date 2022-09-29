Public Class EquipSlotDataTests
    Private Sub WithEquipSlotData(stuffToDo As Action(Of Mock(Of IStore), IEquipSlotData))
        Dim store As New Mock(Of IStore)
        Dim subject As IEquipSlotData = New EquipSlotData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadNameOfAGivenEquipSlot()
        WithEquipSlotData(
            Sub(store, subject)
                Const equipSlotId = 1L
                subject.ReadName(equipSlotId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnString(
                        It.IsAny(Of Action),
                        Tables.EquipSlots,
                        Columns.EquipSlotNameColumn,
                        (Columns.EquipSlotIdColumn, equipSlotId)))
            End Sub)
    End Sub
End Class
