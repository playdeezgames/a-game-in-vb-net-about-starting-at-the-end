Public Class RouteTypeTests
    Inherits BaseGameTests(Of IRouteType)
    Sub New()
        MyBase.New(AddressOf RouteType.FromId)
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
            End Sub)
    End Sub
    <Fact>
    Sub ShouldFetchAUseEventNameFromTheDataStore()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.RouteType.ReadUseEventName(It.IsAny(Of Long)))
                subject.UseEventName.ShouldBeNull
                worldData.Verify(Function(x) x.RouteType.ReadUseEventName(id))
            End Sub)
    End Sub
End Class
