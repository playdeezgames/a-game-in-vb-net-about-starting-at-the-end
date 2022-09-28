Module Program
    Sub Main(args As String())
        load_music(0, "./Assets/Final_Boss.txt")
        start_tracker_thread()
        change_music(0)
        Console.Title = "A Game in VB.NET About Starting at the End"
        AddHandler SfxPlayer.PlaySfx, AddressOf SfxHandler.HandleSfx
        TitleProcessor.Run()
        MainMenuProcessor.Run()
        end_tracker_thread()
    End Sub
End Module
