Friend Class EventsData
    Implements IEventsData

    Public Sub Raise(eventName As String, characterId As Long) Implements IEventsData.Raise
        Throw New NotImplementedException()
    End Sub
End Class
