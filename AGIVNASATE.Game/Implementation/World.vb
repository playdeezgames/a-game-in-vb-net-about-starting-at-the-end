Public Class World
    Implements IWorld
    Private ReadOnly WorldData As IWorldData
    Sub New(worldData As IWorldData)
        Me.WorldData = worldData
    End Sub

    Public ReadOnly Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            Return Character.FromId(WorldData, WorldData.Player.ReadCharacterId())
        End Get
    End Property
End Class
