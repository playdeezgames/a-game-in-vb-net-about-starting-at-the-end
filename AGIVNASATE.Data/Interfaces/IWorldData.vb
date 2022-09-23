Public Interface IWorldData
    ReadOnly Property Character As ICharacterData
    ReadOnly Property CharacterItem As ICharacterItemData
    ReadOnly Property CharacterLocationEsteem As ICharacterLocationEsteemData
    ReadOnly Property CharacterStatistic As ICharacterStatisticData
    ReadOnly Property Inventory As IInventoryData
    ReadOnly Property InventoryItem As IInventoryItemData
    ReadOnly Property ItemType As IItemTypeData
    ReadOnly Property Location As ILocationData
    ReadOnly Property LocationItem As ILocationItemData
    ReadOnly Property Player As IPlayerData
    ReadOnly Property Route As IRouteData
    Sub Save(filename As String)
End Interface
