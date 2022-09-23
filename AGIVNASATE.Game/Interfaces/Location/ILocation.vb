Public Interface ILocation
    Inherits IBaseThingie
    ReadOnly Property Name As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property Navigation As ILocationNavigation
    ReadOnly Property Inventory As ILocationInventory
End Interface
