Module Module1

    Sub Main()
        Dim cities As New List(Of City)() From _
        {
            New City With {.Country = "Vietnam", .Name = "Ha Noi"},
            New City With {.Country = "USA", .Name = "New York"},
            New City With {.Country = "Tokyo", .Name = "Japan"},
            New City With {.Country = "Milan", .Name = "Spain"},
            New City With {.Country = "Amsterdam", .Name = "Netherland"},
            New City With {.Country = "Vietnam", .Name = "Bac Giang"}
        }

        Console.WriteLine("******************* Before order *******************")
        For Each item In cities
            Console.WriteLine(item.Name + " of " + item.Country)
        Next
        cities = cities.OrderBy(Function(c) c.Country).ToList()

        Console.WriteLine("******************* After order by country *******************")
        For Each item1 In cities
            Console.WriteLine(item1.Name + " of " + item1.Country)
        Next
        Console.WriteLine("******************* After order by country the name *******************")
        cities = cities.OrderBy(Function(c) c.Country).ThenBy(Function(n) n.Name).ToList()
        For Each item2 In cities
            Console.WriteLine(item2.Name + " of " + item2.Country)
        Next

        Console.Read()
    End Sub

    Class City
        Public Property Name As String
        Public Property Country As String
    End Class

End Module
