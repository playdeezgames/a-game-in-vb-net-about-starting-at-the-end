Public Interface ICharacterData
    Function ReadName(characterId As Long) As String
    Function ReadLocation(characterId As Long) As Long?
    Sub WriteLocation(characterId As Long, locationId As Long)
    Function ReadForLocation(locationId As Long) As IEnumerable(Of Long)
    Sub Clear(characterId As Long)
End Interface
