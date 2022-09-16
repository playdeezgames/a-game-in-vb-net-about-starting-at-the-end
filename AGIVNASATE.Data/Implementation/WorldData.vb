Public Class WorldData
    Implements IWorldData
    Sub New(store As IStore)
        Character = New CharacterData(store)
        Location = New LocationData(store)
        Player = New PlayerData(store)
    End Sub

    Public ReadOnly Property Player As IPlayerData Implements IWorldData.Player
    Public ReadOnly Property Character As ICharacterData Implements IWorldData.Character

    Public ReadOnly Property Location As ILocationData Implements IWorldData.Location
End Class
