Imports AGIVNASATE

Public Class EventsData
    Implements IEventsData
    Public Property WorldData As IWorldData
    Private ReadOnly handlers As IReadOnlyDictionary(Of String, Func(Of IReadOnlyList(Of Long), String)) =
        New Dictionary(Of String, Func(Of IReadOnlyList(Of Long), String)) From
        {
            {"UsePortalScroll",
                Function(parms)
                    Dim character = Game.Character.FromId(WorldData, parms(0))
                    Dim itemType = Game.ItemType.FromId(WorldData, parms(1))
                    Return $"{character.Name} uses the {itemType.Name}."
                End Function}
        }
    Public Function Raise(eventName As String, ParamArray parms As Long()) As String Implements IEventsData.Raise
        Return handlers(eventName)(parms)
    End Function
End Class
