Public Class BaseData
    Protected Store As IStore
    Sub New(store As IStore)
        Me.Store = store
    End Sub
    Protected Sub NoInitializer()
        'do nothing
    End Sub
End Class
