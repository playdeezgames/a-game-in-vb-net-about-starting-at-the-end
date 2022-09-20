Public Class CharacterStatistics
    Inherits BaseThingie
    Implements ICharacterStatistics

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacterStatistics
        Return If(id.HasValue, New CharacterStatistics(worldData, id.Value), Nothing)
    End Function
    Public ReadOnly Property Satiety As (Long, Long) Implements ICharacterStatistics.Satiety
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
    Public ReadOnly Property Health As (Long, Long) Implements ICharacterStatistics.Health
        Get
            Dim maxHealth = MaximumHealth
            Return (maxHealth - Wounds, maxHealth)
        End Get
    End Property
    Const AttackStatisticTypeId = 5L
    Public ReadOnly Property Attack As Long Implements ICharacterStatistics.Attack
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, AttackStatisticTypeId), 0)
        End Get
    End Property
    Const DefendStatisticTypeId = 6L
    Public ReadOnly Property Defend As Long Implements ICharacterStatistics.Defend
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, DefendStatisticTypeId), 0)
        End Get
    End Property

    Public ReadOnly Property IsDead As Boolean Implements ICharacterStatistics.IsDead
        Get
            Return True
        End Get
    End Property

    Public Property Wounds As Long Implements ICharacterStatistics.Wounds
        Get
            Return If(WorldData.CharacterStatistic.Read(Id, WoundsStatisticTypeId), 0)
        End Get
        Set(value As Long)
            WorldData.CharacterStatistic.Write(Id, WoundsStatisticTypeId, value)
        End Set
    End Property
End Class
