Imports System.IO
Imports System.Text.RegularExpressions

Module MinCSS

    Sub Main()
        Dim minstyle As String = RemoveWhiteSpaceFromStylesheets(File.ReadAllText("..\..\style.css"))
        File.WriteAllText("..\..\style-min.css", minstyle)
        Console.Write("Done!")
        Console.Read()
    End Sub

    Public Function RemoveWhiteSpaceFromStylesheets(ByVal body As String) As String
        body = Regex.Replace(body, "[a-zA-Z]+#", "#")
        body = Regex.Replace(body, "[\n\r]+\s*", String.Empty)
        body = Regex.Replace(body, "\s+", " ")
        body = Regex.Replace(body, "\s?([:,;{}])\s?", "$1")
        body = body.Replace(";}", "}")
        body = Regex.Replace(body, "([\s:]0)(px|pt|%|em)", "$1")
        ' Remove comments from CSS
        body = Regex.Replace(body, "/\*[\d\D]*?\*/", String.Empty)
        Return body
    End Function

End Module
