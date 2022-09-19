Public Class CharacterNavigation
    Inherits BaseThingie
    Implements ICharacterNavigation

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Friend Shared Function FromId(worldData As IWorldData, id As Long) As ICharacterNavigation
        Return New CharacterNavigation(worldData, id)
    End Function
    Public ReadOnly Property Location As ILocation Implements ICharacterNavigation.Location
        Get
            Return AGIVNASATE.Game.Location.FromId(WorldData, WorldData.Character.ReadLocation(Id))
        End Get
    End Property
End Class
