Public Class Game
    Implements IGame
    Private ReadOnly WorldData As IWorldData
    Sub New(worldData As IWorldData)
        Me.WorldData = worldData
    End Sub

    Public Sub EndGame() Implements IGame.EndGame
    End Sub
End Class
