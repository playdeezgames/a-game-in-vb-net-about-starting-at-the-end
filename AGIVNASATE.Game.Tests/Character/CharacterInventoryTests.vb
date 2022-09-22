Public Class CharacterInventoryTests
    Inherits BaseGameTests(Of ICharacterInventory)
    Public Sub New()
        MyBase.New(AddressOf CharacterInventory.FromId)
    End Sub
    <Fact>
    Sub ShouldCreateACharacterInventoryObject()
        WithSubject(
            Sub(worldData, id, subject)
                subject.ShouldNotBeNull
            End Sub)
    End Sub
End Class
