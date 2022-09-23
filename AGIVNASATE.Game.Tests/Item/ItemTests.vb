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
End Class
