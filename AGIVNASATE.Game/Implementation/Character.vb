Public Class Character
    Inherits BaseThingie
    Implements ICharacter

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return WorldData.Character.ReadName(Id)
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return AGIVNASATE.Game.Location.FromId(WorldData, WorldData.Character.ReadLocation(Id))
        End Get
    End Property

    Public ReadOnly Property Satiety As (Long, Long) Implements ICharacter.Satiety
        Get
            Dim maxSatiety = MaximumSatiety
            Return (maxSatiety - Hunger, MaximumSatiety)
        End Get
    End Property
    Const MaximumSatietyStatisticTypeId = 1L
    Private ReadOnly Property MaximumSatiety As Long
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, MaximumSatietyStatisticTypeId), 0)
        End Get
    End Property
    Const HungerStatisticTypeId = 2L
    Private ReadOnly Property Hunger As Long
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, HungerStatisticTypeId), 0)
        End Get
    End Property

    Public Sub Move(route As IRoute) Implements ICharacter.Move
        WorldData.Character.WriteLocation(Id, route.ToLocation.Id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacter
        Return If(id.HasValue, New Character(worldData, id.Value), Nothing)
    End Function
End Class
