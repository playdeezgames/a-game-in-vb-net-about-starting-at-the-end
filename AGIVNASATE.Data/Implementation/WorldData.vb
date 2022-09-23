Public Class WorldData
    Implements IWorldData
    Private Store As IStore
    Sub New(store As IStore)
        Me.Store = store
        Character = New CharacterData(store)
        CharacterItem = New CharacterItemData(store)
        CharacterLocationEsteem = New CharacterLocationEsteemData(store)
        CharacterStatistic = New CharacterStatisticData(store)
        Inventory = New InventoryData(store)
        InventoryItem = New ItemData(store)
        ItemType = New ItemTypeData(store)
        Location = New LocationData(store)
        LocationItem = New LocationItemData(store)
        Player = New PlayerData(store)
        Route = New RouteData(store)
    End Sub

    Public ReadOnly Property Player As IPlayerData Implements IWorldData.Player
    Public ReadOnly Property Character As ICharacterData Implements IWorldData.Character
    Public ReadOnly Property Location As ILocationData Implements IWorldData.Location
    Public ReadOnly Property Route As IRouteData Implements IWorldData.Route
    Public ReadOnly Property CharacterStatistic As ICharacterStatisticData Implements IWorldData.CharacterStatistic
    Public ReadOnly Property CharacterLocationEsteem As ICharacterLocationEsteemData Implements IWorldData.CharacterLocationEsteem
    Public ReadOnly Property CharacterItem As ICharacterItemData Implements IWorldData.CharacterItem
    Public ReadOnly Property ItemType As IItemTypeData Implements IWorldData.ItemType
    Public ReadOnly Property Inventory As IInventoryData Implements IWorldData.Inventory
    Public ReadOnly Property InventoryItem As IInventoryItemData Implements IWorldData.InventoryItem
    Public ReadOnly Property LocationItem As ILocationItemData Implements IWorldData.LocationItem

    Public Sub Save(filename As String) Implements IWorldData.Save
        Store.Save(filename)
    End Sub
End Class
