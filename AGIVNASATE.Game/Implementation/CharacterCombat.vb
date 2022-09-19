Public Class CharacterCombat
    Inherits BaseThingie
    Implements ICharacterCombat

    Public Sub New(worlddata As IWorldData, id As Long)
        MyBase.New(worlddata, id)
    End Sub

    Public Shared Function FromId(worldData As IWorldData, id As Long) As ICharacterCombat
        Return New CharacterCombat(worldData, id)
    End Function
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
End Class
