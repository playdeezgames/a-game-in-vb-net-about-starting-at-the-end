Public Class LocationTests
    Inherits BaseGameTests(Of ILocation)
    Sub New()
        MyBase.New(AddressOf Location.FromId)
    End Sub
    <Fact>
    Sub ShouldHoldAnIdNumber()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Id.ShouldBe(id)
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveAGivenLocationsNameFromTheData()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.SetupGet(Function(x) x.Location).Returns((New Mock(Of ILocationData)).Object)
                subject.Name.ShouldBeNull
                worldData.Verify(Function(x) x.Location.ReadName(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldRetrieveCharactersInAGivenLocation()
        WithSubject(
            Sub(worldData, id, subject)
                worldData.Setup(Function(x) x.Character.ReadForLocation(It.IsAny(Of Long)))
                subject.Characters.ShouldBeEmpty
                worldData.Verify(Function(x) x.Character.ReadForLocation(id))
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAccessToTheLocationNavigationSubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Navigation.ShouldNotBeNull
            End Sub)
    End Sub
    <Fact>
    Sub ShouldGiveAccessToTheLocationInventorySubobject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.Inventory.ShouldNotBeNull
            End Sub)
    End Sub
End Class
