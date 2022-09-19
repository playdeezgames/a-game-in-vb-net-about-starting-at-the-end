Public Class CharacterCombatTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, ICharacterCombat))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As ICharacterCombat = New CharacterCombat(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
End Class
