﻿Module TitleProcessor
    Sub Run()
        AnsiConsole.Clear()
        Dim figlet As New FigletText("A Game in VB.NET About Starting at the End") With {.Alignment = Justify.Center, .Color = Color.Teal}
        AnsiConsole.Write(figlet)
        SfxPlayer.Play(Sfx.Title)
        OkPrompt()
    End Sub
End Module
