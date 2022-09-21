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

    Public ReadOnly Property Combat As ICharacterCombat Implements ICharacter.Combat
        Get
            Return CharacterCombat.FromId(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property HasInventory As Boolean Implements ICharacter.HasInventory
        Get
            Return WorldData.CharacterItem.ReadCountForCharacter(Id) > 0L
        End Get
    End Property

    Public ReadOnly Property ItemStacks As IReadOnlyDictionary(Of IItemType, IEnumerable(Of IItem)) Implements ICharacter.ItemStacks
        Get
            Return WorldData.CharacterItem.ReadForCharacter(Id).
                GroupBy(Function(x) x.Item2).
                ToDictionary(Function(x) ItemType.FromId(WorldData, x.Key),
                             Function(x) x.Select(Function(y) Item.FromId(WorldData, y.Item1)))
        End Get
    End Property

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacter
        Return If(id.HasValue, New Character(worldData, id.Value), Nothing)
    End Function
End Class
