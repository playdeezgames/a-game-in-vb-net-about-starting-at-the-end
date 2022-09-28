Module UseSingleUsePortalProcessor
    Friend Function Run(character As ICharacter, route As IRoute) As String
        route.Destroy()
        Return Nothing
    End Function
End Module
