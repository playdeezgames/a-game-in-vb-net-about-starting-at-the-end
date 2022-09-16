Module Program
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About Starting at the End"
        AddHandler SfxPlayer.PlaySfx, AddressOf SfxHandler.HandleSfx
        TitleProcessor.Run()
        MainMenuProcessor.Run()
    End Sub
End Module
