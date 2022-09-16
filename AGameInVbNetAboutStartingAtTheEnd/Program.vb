Module Program
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About Starting at the End"
        AnsiConsole.Clear()
        Dim figlet As New FigletText("A Game in VB.NET About Starting at the End") With {.Alignment = Justify.Center, .Color = Color.Teal}
        AnsiConsole.Write(figlet)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("OK")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
