Public Class WorldDataTests
    <Fact>
    Sub ShouldHaveSubobjects()
        Dim store As New Mock(Of IStore)
        Dim subject As IWorldData = New WorldData(store.Object)
        subject.Character.ShouldNotBeNull
        subject.CharacterItem.ShouldNotBeNull
        subject.CharacterLocationEsteem.ShouldNotBeNull
        subject.CharacterStatistic.ShouldNotBeNull
        subject.Inventory.ShouldNotBeNull
        subject.InventoryItem.ShouldNotBeNull
        subject.ItemType.ShouldNotBeNull
        subject.Location.ShouldNotBeNull
        subject.Player.ShouldNotBeNull
        subject.Route.ShouldNotBeNull
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldSaveViaTheStore()
        Const filename = "blah.db"
        Dim store As New Mock(Of IStore)
        Dim subject As IWorldData = New WorldData(store.Object)
        subject.Save(filename)
        store.Verify(Sub(x) x.Save(filename))
        store.VerifyNoOtherCalls()
    End Sub
End Class


