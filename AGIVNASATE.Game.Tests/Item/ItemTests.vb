Public Class ItemTests
    Inherits BaseGameTests(Of IItem)

    Public Sub New()
        MyBase.New(AddressOf Item.FromId)
    End Sub

    <Fact>
    Sub ShouldCreateAnItem()
        WithSubject(
            Sub(worldData, id, subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldDestroyAnItem()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Sub(x) x.Item.Clear(It.IsAny(Of Long)))
                subject.Destroy()
                worldData.Verify(Sub(x) x.Item.Clear(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldReadTheNameOfAGivenItem()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.ItemName.Read(It.IsAny(Of Long)))
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.ItemName.Read(id))
            End Sub)
    End Sub
End Class
