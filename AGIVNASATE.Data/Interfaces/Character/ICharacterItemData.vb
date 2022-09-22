Public Interface ICharacterItemData
    Function ReadCountForCharacter(characterId As Long) As Long
    Function ReadForCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long))
    Function ReadForItemType(characterId As Long, itemTypeId As Long) As IEnumerable(Of Long)
End Interface
