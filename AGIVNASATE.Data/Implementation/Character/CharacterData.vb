Public Class CharacterData
    Inherits BaseData
    Implements ICharacterData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub WriteLocation(characterId As Long, locationId As Long) Implements ICharacterData.WriteLocation
        Store.WriteColumnValue(
            AddressOf NoInitializer,
            Tables.Characters,
            (Columns.LocationIdColumn, locationId),
            (Columns.CharacterIdColumn, characterId))
    End Sub

    Public Sub Clear(characterId As Long) Implements ICharacterData.Clear
        Store.ClearForColumnValue(
            AddressOf NoInitializer,
            Tables.Characters,
            (Columns.CharacterIdColumn, characterId))
    End Sub

    Public Function ReadName(characterId As Long) As String Implements ICharacterData.ReadName
        Return Store.ReadColumnString(
            AddressOf NoInitializer,
            Tables.Characters,
            Columns.CharacterNameColumn,
            (Columns.CharacterIdColumn, characterId))
    End Function

    Public Function ReadLocation(characterId As Long) As Long? Implements ICharacterData.ReadLocation
        Return Store.ReadColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Characters,
            Columns.LocationIdColumn,
            (Columns.CharacterIdColumn, characterId))
    End Function

    Public Function ReadForLocation(locationId As Long) As IEnumerable(Of Long) Implements ICharacterData.ReadForLocation
        Return Store.ReadRecordsWithColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Characters,
            Columns.CharacterIdColumn,
            (Columns.LocationIdColumn, locationId))
    End Function
End Class
