Public Class Game
    Implements IGame
    Private ReadOnly WorldData As IWorldData
    Sub New(worldData As IWorldData)
        Me.WorldData = worldData
    End Sub

    Public ReadOnly Property PlayerCharacter As ICharacter Implements IGame.PlayerCharacter
        Get
            Return Character.FromId(WorldData, WorldData.Player.ReadCharacterId())
        End Get
    End Property

    Public Sub EndGame() Implements IGame.EndGame
    End Sub
End Class
