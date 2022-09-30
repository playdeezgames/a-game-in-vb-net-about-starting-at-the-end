Public Class InventoryData
    Inherits BaseData
    Implements IInventoryData

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Sub ClearForCharacter(characterId As Long) Implements IInventoryData.ClearForCharacter
        Store.ClearForColumnValue(
            AddressOf NoInitializer,
            Tables.Inventories,
            (Columns.CharacterIdColumn, characterId))
    End Sub

    Public Function ReadForLocation(locationId As Long) As Long? Implements IInventoryData.ReadForLocation
        Return Store.ReadColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Inventories,
            Columns.InventoryIdColumn,
            (Columns.LocationIdColumn, locationId))
    End Function

    Public Function CreateForLocation(locationId As Long) As Long Implements IInventoryData.CreateForLocation
        Return Store.CreateRecord(
            AddressOf NoInitializer,
            Tables.Inventories,
            (Columns.LocationIdColumn, locationId))
    End Function

    Public Function ReadForCharacter(characterId As Long) As Long? Implements IInventoryData.ReadForCharacter
        Return Store.ReadColumnValue(Of Long, Long)(
                        AddressOf NoInitializer,
                        Tables.Inventories,
                        Columns.InventoryIdColumn,
                        (Columns.CharacterIdColumn, characterId))
    End Function

    Public Function CreateForCharacter(characterId As Long) As Long Implements IInventoryData.CreateForCharacter
        Return Store.CreateRecord(
                        AddressOf NoInitializer,
                        Tables.Inventories,
                        (Columns.CharacterIdColumn, characterId))
    End Function
End Class
