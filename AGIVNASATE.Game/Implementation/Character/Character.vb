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

    Public ReadOnly Property Inventory As ICharacterInventory Implements ICharacter.Inventory
        Get
            Return CharacterInventory.FromId(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements ICharacter.World
        Get
            Return New World(WorldData)
        End Get
    End Property

    Public ReadOnly Property HasEquipment As Boolean Implements ICharacter.HasEquipment
        Get
            Return WorldData.CharacterEquippedItem.CountForCharacter(Id) > 0
        End Get
    End Property

    Public ReadOnly Property EquippedItems As IReadOnlyDictionary(Of IEquipSlot, IItem) Implements ICharacter.EquippedItems
        Get
            Dim results As IEnumerable(Of Tuple(Of Long, Long)) = WorldData.CharacterEquippedItem.ReadForCharacter(Id)
            Return results.ToDictionary(Function(x) EquipSlot.FromId(WorldData, x.Item1), Function(x) Item.FromId(WorldData, x.Item2))
        End Get
    End Property

    Public Shared Function FromId(worldData As IWorldData, id As Long?) As ICharacter
        Return If(id.HasValue, New Character(worldData, id.Value), Nothing)
    End Function
End Class
