Imports System.Net
Imports System.Linq

Module Module1

    Sub Main()
        Dim client As New WebClient
        Dim str As String = client.DownloadString("http://code2code.info/sitemap.xml")
        Dim element As XElement = XElement.Parse(str)
        Dim e = From i In element.Elements() _
            Select i.FirstNode
        For Each item As XNode In e
            Dim url As String = (DirectCast(item, XElement)).Value
            Console.WriteLine(url)
        Next
        Console.Read()
    End Sub

End Module
