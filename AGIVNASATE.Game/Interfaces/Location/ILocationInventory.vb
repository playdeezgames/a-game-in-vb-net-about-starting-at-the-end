Public Interface ILocationInventory
    Inherits IBaseThingie
    Sub AddItem(item As IItem)
    Function HasItems() As Boolean
End Interface
