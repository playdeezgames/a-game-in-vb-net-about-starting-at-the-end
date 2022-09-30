Public Interface IInventoryData
    Function ReadForLocation(locationId As Long) As Long?
    Function CreateForLocation(locationId As Long) As Long
    Function ReadForCharacter(characterId As Long) As Long?
    Function CreateForCharacter(characterId As Long) As Long
    Sub ClearForCharacter(characterId As Long)
End Interface
