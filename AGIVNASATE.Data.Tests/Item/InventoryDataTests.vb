Public Class InventoryDataTests
    Private Sub WithInventoryDta(stuffToDo As Action(Of Mock(Of IStore), IInventoryData))
        Dim store As New Mock(Of IStore)
        Dim subject As IInventoryData = New InventoryData(store.Object)
        stuffToDo(store, subject)
        store.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldReadTheInventoryIdForAGivenLocation()
        WithInventoryDta(
            Sub(store, subject)
                Const locationId = 1L
                subject.ReadForLocation(locationId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Inventories,
                        Columns.InventoryIdColumn,
                        (Columns.LocationIdColumn, locationId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCreateAnInventoryForAGivenLocation()
        WithInventoryDta(
            Sub(store, subject)
                Const locationId = 1L
                subject.CreateForLocation(locationId).ShouldBe(0)
                store.Verify(
                    Function(x) x.CreateRecord(
                        It.IsAny(Of Action),
                        Tables.Inventories,
                        (Columns.LocationIdColumn, locationId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadTheInventoryIdForAGivenCharacter()
        WithInventoryDta(
            Sub(store, subject)
                Const characterId = 1L
                subject.ReadForCharacter(characterId).ShouldBeNull
                store.Verify(
                    Function(x) x.ReadColumnValue(Of Long, Long)(
                        It.IsAny(Of Action),
                        Tables.Inventories,
                        Columns.InventoryIdColumn,
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldCreateAnInventoryForAGivenCharacter()
        WithInventoryDta(
            Sub(store, subject)
                Const characterId = 1L
                subject.CreateForCharacter(characterId).ShouldBe(0)
                store.Verify(
                    Function(x) x.CreateRecord(
                        It.IsAny(Of Action),
                        Tables.Inventories,
                        (Columns.CharacterIdColumn, characterId)))
            End Sub)
    End Sub
End Class
