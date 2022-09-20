Public Class CharacterCombat
    Inherits BaseThingie
    Implements ICharacterCombat

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacterCombat
        Return If(id.HasValue, New CharacterCombat(worldData, id.Value), Nothing)
    End Function

    Public Function Attack(defender As ICharacter) As (Long, Boolean) Implements ICharacterCombat.Attack
        Dim attackStrength = Statistics.Attack
        Dim defendStrength = defender.Statistics.Defend
        Dim damage = Math.Max(0, attackStrength - defendStrength)
        defender.Combat.DoDamage(damage)
        Return (damage, defender.Statistics.IsDead)
    End Function

    Public Sub DoDamage(damage As Long) Implements ICharacterCombat.DoDamage
        Statistics.Wounds += damage
    End Sub

    Public ReadOnly Property CanFight As Boolean Implements ICharacterCombat.CanFight
        Get
            Return WorldData.CharacterLocationEsteem.ReadForFromCharacter(Id).Any(Function(x) x.Item2 < 0)
        End Get
    End Property
    Public ReadOnly Property Enemies As IEnumerable(Of ICharacter) Implements ICharacterCombat.Enemies
        Get
            Return WorldData.CharacterLocationEsteem.ReadForFromCharacter(Id).
                Where(Function(x) x.Item2 < 0).
                Select(Function(x) Character.FromId(WorldData, x.Item1))
        End Get
    End Property

    Public ReadOnly Property Statistics As ICharacterStatistics Implements ICharacterCombat.Statistics
        Get
            Return CharacterStatistics.FromId(WorldData, Id)
        End Get
    End Property
End Class
