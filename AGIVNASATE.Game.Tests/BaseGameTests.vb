Public MustInherit Class BaseGameTests(Of TThingie)
    Private ReadOnly thingieMaker As Func(Of IWorldData, Long?, TThingie)
    Sub New(thingieMaker As Func(Of IWorldData, Long?, TThingie))
        Me.thingieMaker = thingieMaker
    End Sub
    Protected Sub WithSubject(
                            stuffToDo As Action(Of Mock(Of IWorldData), Long, TThingie))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As TThingie = thingieMaker(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
End Class
