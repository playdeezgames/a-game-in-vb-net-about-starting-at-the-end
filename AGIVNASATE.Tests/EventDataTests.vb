Public Class EventDataTests
    Private Sub WithEventsData(stuffToDo As Action(Of Mock(Of IWorldData), IEventsData))
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As EventsData = New EventsData
        subject.WorldData = worldData.Object
        stuffToDo(worldData, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldHandleUsePortalScroll()
        WithEventsData(
            Sub(worldData, subject)
                Const eventName = "UsePortalScroll"
                Const characterId = 1L
                Const itemTypeId = 2L
                worldData.Setup(Function(x) x.Character.ReadName(It.IsAny(Of Long)))
                worldData.Setup(Function(x) x.ItemType.ReadName(It.IsAny(Of Long)))
                worldData.Setup(Function(x) x.CharacterItem.ReadForItemType(It.IsAny(Of Long), It.IsAny(Of Long)))
                subject.Raise(eventName, characterId, itemTypeId).ShouldBe(" has no .")
                worldData.Verify(Function(x) x.Character.ReadName(characterId))
                worldData.Verify(Function(x) x.ItemType.ReadName(itemTypeId))
                worldData.Verify(Function(x) x.CharacterItem.ReadForItemType(characterId, itemTypeId))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldHandleUseSingleUsePortal()
        WithEventsData(
            Sub(worldData, subject)
                Const eventName = "UseSingleUsePortal"
                Const characterId = 1L
                Const routeId = 2L
                worldData.Setup(Sub(x) x.Route.Clear(It.IsAny(Of Long)))
                subject.Raise(eventName, characterId, routeId).ShouldBeNull
                worldData.Verify(Sub(x) x.Route.Clear(routeId))
            End Sub)
    End Sub
End Class