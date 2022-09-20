Public Class WorldData
    Implements IWorldData
    Private Store As IStore
    Sub New(store As IStore)
        Me.Store = store
        Character = New CharacterData(store)
        CharacterLocationEsteem = New CharacterLocationEsteemData(store)
        CharacterStatistic = New CharacterStatisticData(store)
        Location = New LocationData(store)
        Player = New PlayerData(store)
        Route = New RouteData(store)
    End Sub

    Public ReadOnly Property Player As IPlayerData Implements IWorldData.Player
    Public ReadOnly Property Character As ICharacterData Implements IWorldData.Character
    Public ReadOnly Property Location As ILocationData Implements IWorldData.Location
    Public ReadOnly Property Route As IRouteData Implements IWorldData.Route
    Public ReadOnly Property CharacterStatistic As ICharacterStatisticData Implements IWorldData.CharacterStatistic
    Public ReadOnly Property CharacterLocationEsteem As ICharacterLocationEsteemData Implements IWorldData.CharacterLocationEsteem

    Public Sub Save(filename As String) Implements IWorldData.Save
        Store.Save(filename)
    End Sub
End Class
