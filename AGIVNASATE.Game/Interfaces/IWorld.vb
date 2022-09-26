Public Interface IWorld
    ReadOnly Property PlayerCharacter As ICharacter
    ReadOnly Property StartLocation As ILocation
    Sub Save(filename As String)
End Interface
