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
    Public ReadOnly Property CanFight As Boolean Implements ICharacter.CanFight
        Get
            Return WorldData.CharacterLocationEsteem.ReadForFromCharacter(Id).Any(Function(x) x.Item2 < 0)
        End Get
    End Property
    Public ReadOnly Property Enemies As IEnumerable(Of ICharacter) Implements ICharacter.Enemies
        Get
            Return WorldData.CharacterLocationEsteem.ReadForFromCharacter(Id).
                Where(Function(x) x.Item2 < 0).
                Select(Function(x) Character.FromId(WorldData, x.Item1))
        End Get
    End Property

    Public ReadOnly Property Navigation As ICharacterNavigation Implements ICharacter.Navigation
        Get
            Return CharacterNavigation.FromId(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property Statistics As ICharacterStatistics Implements ICharacter.Statistics
        Get
            Return CharacterStatistics.FromId(WorldData, Id)
        End Get
    End Property

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacter
        Return If(id.HasValue, New Character(worldData, id.Value), Nothing)
    End Function
End Class
