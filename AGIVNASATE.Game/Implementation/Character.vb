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
    Const MaximumHealthStatisticTypeId = 3L
    Private ReadOnly Property MaximumHealth As Long
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, MaximumHealthStatisticTypeId), 0)
        End Get
    End Property
    Const HungerStatisticTypeId = 2L
    Private ReadOnly Property Hunger As Long
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, HungerStatisticTypeId), 0)
        End Get
    End Property
    Const WoundsStatisticTypeId = 4L
    Private ReadOnly Property Wounds As Long
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, WoundsStatisticTypeId), 0)
        End Get
    End Property
    Public ReadOnly Property Health As (Long, Long) Implements ICharacter.Health
        Get
            Dim maxHealth = MaximumHealth
            Return (maxHealth - Wounds, maxHealth)
        End Get
    End Property
    Const AttackStatisticTypeId = 5L
    Public ReadOnly Property Attack As Long Implements ICharacter.Attack
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, AttackStatisticTypeId), 0)
        End Get
    End Property
    Const DefendStatisticTypeId = 6L
    Public ReadOnly Property Defend As Long Implements ICharacter.Defend
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, DefendStatisticTypeId), 0)
        End Get
    End Property

    Public ReadOnly Property CanFight As Boolean Implements ICharacter.CanFight
        Get
            Return False
        End Get
    End Property

    Public Sub Move(route As IRoute) Implements ICharacter.Move
        WorldData.Character.WriteLocation(Id, route.ToLocation.Id)
    End Sub
    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacter
        Return If(id.HasValue, New Character(worldData, id.Value), Nothing)
    End Function
End Class
