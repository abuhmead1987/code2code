Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Text.RegularExpressions

Module Module1

    Sub Main()
        Dim allUrls As New List(Of String)
        Dim client As New WebClient()
        Dim content As String = client.DownloadString("http://code2code.info")
        Dim pattern As String = "(?i)(?s)<a[^>]+?href=""?(?<url>[^""]+)""?>(?<innerHtml>.+?)</a\s*>"
        Dim resut As MatchCollection = Regex.Matches(content, pattern)
        For Each Match As Match In resut
            Dim url As String = Match.Groups("url").Value
            If url.IndexOf("http://") <> -1 Then
                allUrls.Add(url)
            End If
            Console.WriteLine(url)
        Next
        Console.WriteLine(allUrls.Count)
        Console.Read()
    End Sub

End Module
