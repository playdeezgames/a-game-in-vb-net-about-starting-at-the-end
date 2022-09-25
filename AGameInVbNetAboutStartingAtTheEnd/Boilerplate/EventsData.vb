Friend Class EventsData
    Implements IEventsData
    Public Property World As IWorld
    Public Function Raise(eventName As String, characterId As Long) As String Implements IEventsData.Raise
        Return "Nothing happens."
    End Function
End Class
