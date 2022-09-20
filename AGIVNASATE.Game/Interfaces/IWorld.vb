Public Interface IWorld
    ReadOnly Property PlayerCharacter As ICharacter
    Sub Save(filename As String)
End Interface
