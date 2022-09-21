Public Interface ICharacterItemData
    Function ReadCountForCharacter(characterId As Long) As Long
    Function ReadForCharacter(id As Long) As IEnumerable(Of Tuple(Of Long, Long))
End Interface
