Public Interface IWorldData
    ReadOnly Property Character As ICharacterData
    ReadOnly Property CharacterLocationEsteem As ICharacterLocationEsteemData
    ReadOnly Property CharacterStatistic As ICharacterStatisticData
    ReadOnly Property Location As ILocationData
    ReadOnly Property Player As IPlayerData
    ReadOnly Property Route As IRouteData
    Sub Save(filename As String)
End Interface
