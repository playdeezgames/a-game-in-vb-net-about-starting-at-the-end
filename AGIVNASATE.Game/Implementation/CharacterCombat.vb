Public Class CharacterCombat
    Inherits BaseThingie
    Implements ICharacterCombat

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Friend Shared Function FromId(worldData As IWorldData, id As Long) As ICharacterCombat
        Return New CharacterCombat(worldData, id)
    End Function
End Class
