Module Module1

    Sub Main()
        Dim name As String() = {"NeonQuach", "QuachNguyen"}
        If name.Contains("neonquach", StringComparer.OrdinalIgnoreCase) Then
            Console.WriteLine("compare with no case-sensitive, neonquach exits in name array")
        ElseIf name.Contains("neonquach") Then
            Console.WriteLine("compare with case-sensitive")
        End If
        Console.Read()
    End Sub

End Module
