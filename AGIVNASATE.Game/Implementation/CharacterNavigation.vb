Public Class CharacterNavigation
    Inherits BaseThingie
    Implements ICharacterNavigation

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacterNavigation
        Return If(id.HasValue, New CharacterNavigation(worldData, id.Value), Nothing)
    End Function
    Public ReadOnly Property Location As ILocation Implements ICharacterNavigation.Location
        Get
            Return AGIVNASATE.Game.Location.FromId(WorldData, WorldData.Character.ReadLocation(Id))
        End Get
    End Property
    Public Sub Move(route As IRoute) Implements ICharacterNavigation.Move
        WorldData.Character.WriteLocation(Id, route.ToLocation.Id)
    End Sub
End Class
