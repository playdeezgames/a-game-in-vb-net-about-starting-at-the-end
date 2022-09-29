Public Interface ICharacterEquippedItemData
    Sub Write(characterId As Long, equipSlotId As Long, itemId As Long)
    Function CountForCharacter(characterId As Long) As Long
    Function ReadForCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long))
End Interface
