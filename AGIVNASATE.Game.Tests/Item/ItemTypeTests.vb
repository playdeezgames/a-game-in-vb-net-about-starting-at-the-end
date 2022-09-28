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
                worldData.Setup(Function(x) x.ItemType.ReadUseEventName(It.IsAny(Of Long)))
                subject.CanUse.ShouldBeFalse
                worldData.Verify(Function(x) x.ItemType.ReadUseEventName(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldFetchTheAbilityOfAnItemTypeToBeEquipped()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.ItemTypeEquipSlot.CountForItemType(It.IsAny(Of Long)))
                subject.CanEquip.ShouldBeFalse
                worldData.Verify(Function(x) x.ItemTypeEquipSlot.CountForItemType(id))
            End Sub)
    End Sub
End Class
