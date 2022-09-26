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

    Public ReadOnly Property StartLocation As ILocation Implements IWorld.StartLocation
        Get
            Return Location.FromId(WorldData, WorldData.ReadStartLocation())
        End Get
    End Property

    Public Sub Save(filename As String) Implements IWorld.Save
        WorldData.Save(filename)
    End Sub
End Class
