Public Class EquipSlotTests
    Inherits BaseGameTests(Of IEquipSlot)

    Public Sub New()
        MyBase.New(AddressOf EquipSlot.FromId)
    End Sub

    <Fact>
    Sub ShouldCreateAnEquipSlot()
        WithSubject(
            Sub(worldData, id, subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveMeTheNameOfAGivenEquipSlot()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.EquipSlot.ReadName(It.IsAny(Of Long)))
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.EquipSlot.ReadName(id))
            End Sub)
    End Sub
End Class
