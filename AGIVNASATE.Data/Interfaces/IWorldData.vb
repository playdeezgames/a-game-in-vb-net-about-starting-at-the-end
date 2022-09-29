Public Interface IWorldData
    ReadOnly Property Character As ICharacterData
    ReadOnly Property CharacterEquippedItem As ICharacterEquippedItemData
    ReadOnly Property CharacterItem As ICharacterItemData
    ReadOnly Property CharacterLocationEsteem As ICharacterLocationEsteemData
    ReadOnly Property CharacterStatistic As ICharacterStatisticData
    ReadOnly Property EquipSlot As IEquipSlotData
    ReadOnly Property Events As IEventsData
    ReadOnly Property Inventory As IInventoryData
    ReadOnly Property InventoryItem As IInventoryItemData
    ReadOnly Property Item As IItemData
    ReadOnly Property ItemType As IItemTypeData
    ReadOnly Property ItemTypeEquipSlot As IItemTypeEquipSlotData
    ReadOnly Property Location As ILocationData
    Function ReadStartLocation() As Long?
    ReadOnly Property LocationItem As ILocationItemData
    ReadOnly Property Player As IPlayerData
    ReadOnly Property Route As IRouteData
    ReadOnly Property RouteType As IRouteTypeData
    Sub Save(filename As String)
End Interface
