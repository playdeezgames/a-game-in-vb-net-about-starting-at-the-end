Public Interface ICharacterLocationEsteemData
    Function ReadForFromCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long))
End Interface
