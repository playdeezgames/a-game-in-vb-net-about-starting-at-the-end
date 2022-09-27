Public Class WorldDataTests
    <Fact>
    Sub ShouldHaveSubobjects()
        Dim store As New Mock(Of IStore)
        Dim events As New Mock(Of IEventsData)
        Dim subject As IWorldData = New WorldData(store.Object, events.Object)
        subject.Character.ShouldNotBeNull
        subject.CharacterItem.ShouldNotBeNull
        subject.CharacterLocationEsteem.ShouldNotBeNull
        subject.CharacterStatistic.ShouldNotBeNull
        subject.Events.ShouldNotBeNull
        subject.Inventory.ShouldNotBeNull
        subject.InventoryItem.ShouldNotBeNull
        subject.Item.ShouldNotBeNull
        subject.ItemType.ShouldNotBeNull
        subject.Location.ShouldNotBeNull
        subject.LocationItem.ShouldNotBeNull
        subject.Player.ShouldNotBeNull
        subject.Route.ShouldNotBeNull
        subject.RouteType.ShouldNotBeNull
        store.VerifyNoOtherCalls()
        events.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldSaveViaTheStore()
        Const filename = "blah.db"
        Dim store As New Mock(Of IStore)
        Dim events As New Mock(Of IEventsData)
        Dim subject As IWorldData = New WorldData(store.Object, events.Object)
        subject.Save(filename)
        store.Verify(Sub(x) x.Save(filename))
        store.VerifyNoOtherCalls()
        events.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheStartLoctionFromTheDataStore()
        Dim store As New Mock(Of IStore)
        Dim events As New Mock(Of IEventsData)
        Dim subject As IWorldData = New WorldData(store.Object, events.Object)
        subject.ReadStartLocation().ShouldBeNull
        store.Verify(
            Function(x) x.ReadColumnValue(Of Long, Long)(
                It.IsAny(Of Action),
                Tables.Worlds,
                Columns.StartLocationIdColumn,
                (Columns.WorldIdColumn, 1)))
    End Sub
End Class


