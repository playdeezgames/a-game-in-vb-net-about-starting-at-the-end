Public Class BaseThingie
    Implements IBaseThingie
    Protected WorldData As IWorldData
    ReadOnly Property Id As Long Implements IBaseThingie.Id
    Sub New(worlddata As IWorldData, id As Long)
        Me.WorldData = worlddata
        Me.id = id
    End Sub
End Class
