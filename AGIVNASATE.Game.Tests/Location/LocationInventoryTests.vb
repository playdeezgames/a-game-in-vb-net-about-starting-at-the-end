Public Class LocationInventoryTests
    Inherits BaseGameTests(Of ILocationInventory)
    Sub New()
        MyBase.New(AddressOf LocationInventory.FromId)
    End Sub
    <Fact>
    Sub ShouldAddAnItemToTheAssociatedInventoryOfAGivenLocation()
        WithSubject(
            Sub(worldData, id, subject)
                Const itemId = 2L
                subject.AddItem(Item.FromId(worldData.Object, itemId))
            End Sub)
    End Sub
End Class
