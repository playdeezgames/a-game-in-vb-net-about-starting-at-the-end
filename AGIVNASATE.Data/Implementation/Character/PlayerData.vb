Public Class PlayerData
    Inherits BaseData
    Implements IPlayerData
    Const FixedPlayerId = 1L

    Public Sub New(store As IStore)
        MyBase.New(store)
    End Sub

    Public Function ReadCharacterId() As Long? Implements IPlayerData.ReadCharacterId
        Return Store.ReadColumnValue(Of Long, Long)(
            AddressOf NoInitializer,
            Tables.Players,
            Columns.CharacterIdColumn,
            (Columns.PlayerIdColumn, FixedPlayerId))
    End Function
End Class
