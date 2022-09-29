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
                subject.Name.ShouldBeNull
            End Sub)
    End Sub
End Class
