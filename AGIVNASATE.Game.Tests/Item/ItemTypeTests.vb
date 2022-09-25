Public Class ItemTypeTests
    Inherits BaseGameTests(Of IItemType)
    Sub New()
        MyBase.New(AddressOf ItemType.FromId)
    End Sub
    <Fact>
    Sub ShouldFetchTheNameOfAnItemTypeFromTheWorldData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.ItemType.ReadName(It.IsAny(Of Long)))
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.ItemType.ReadName(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldFetchTheAbilityOfAnItemTypeToBeUsed()
        WithSubject(
            Sub(worldData, id, subject)
                subject.CanUse.ShouldBeFalse
            End Sub)
    End Sub
End Class
