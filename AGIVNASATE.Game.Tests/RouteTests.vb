Public Class RouteTests
    Private Sub WithSubject(stuffToDo As Action(Of Mock(Of IWorldData), Long, IRoute))
        Const id = 1L
        Dim worldData As New Mock(Of IWorldData)
        Dim subject As IRoute = New Route(worldData.Object, id)
        stuffToDo(worldData, id, subject)
        worldData.VerifyNoOtherCalls()
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
            End Sub)
    End Sub
End Class
