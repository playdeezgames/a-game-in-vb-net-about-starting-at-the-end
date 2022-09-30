Public Interface ICharacterStatisticData
    Function Read(characterId As Long, statisticTypeId As Long) As Long?
    Sub Write(characterId As Long, statisticTypeId As Long, statisticValue As Long)
    Sub ClearForCharacter(characterId As Long)
End Interface
