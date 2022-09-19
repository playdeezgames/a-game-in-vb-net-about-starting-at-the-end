Public Class CharacterStatistics
    Inherits BaseThingie
    Implements ICharacterStatistics

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Friend Shared Function FromId(worldData As IWorldData, id As Long) As ICharacterStatistics
        Return New CharacterStatistics(worldData, id)
    End Function
End Class
