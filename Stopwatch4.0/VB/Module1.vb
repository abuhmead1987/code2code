Imports System.Diagnostics
Imports System.Threading

Module Module1

    Sub Main()
        Dim sw As New Stopwatch()
        sw.Start()
        Thread.Sleep(1000)
        Dim timeEslap As String = sw.ElapsedMilliseconds.ToString()
        Console.WriteLine(timeEslap)
        Console.ReadLine()
        sw.Restart()
        Dim timeAfterReset As String = sw.ElapsedMilliseconds.ToString() ' display time after reset sw
        Console.WriteLine(timeAfterReset)
        Console.ReadLine()
    End Sub

End Module
