Public Interface ICharacterEquippedItemData
    Sub Write(characterId As Long, equipSlotId As Long, itemId As Long)
    Function CountForCharacter(characterId As Long) As Long
End Interface
