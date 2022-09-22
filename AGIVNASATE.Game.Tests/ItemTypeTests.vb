Public Class ItemTypeTests
    Inherits BaseGameTests(Of IItemType)
    Sub New()
        MyBase.New(AddressOf ItemType.FromId)
    End Sub
    <Fact>
    Sub ShouldFetchTheNameOfAnItemTypeFromTheWorldData()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Name.ShouldBeNull
            End Sub)
    End Sub
End Class
