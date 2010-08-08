using System;
using System.Collections.Generic;
using System.Linq;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>
            {
                new City{ Country="Vietnam",Name="Ha Noi"},
                new City{ Country="USA",Name="New York"},
                new City{ Country="Tokyo",Name="Japan"},
                new City{ Country="Milan",Name="Spain"},
                new City{ Country="Amsterdam",Name="Netherland"},
                new City{ Country="Vietnam",Name="Bac Giang"},
            };
            Console.WriteLine("******************* Before order *******************");
            foreach (var item in cities)
            {
                Console.WriteLine(item.Name + " of " + item.Country);
            }

            Console.WriteLine("******************* After order by country *******************");
            cities = cities.OrderBy(c => c.Country).ToList<City>();

            foreach (var item1 in cities)
            {
                Console.WriteLine(item1.Name + " of " + item1.Country);
            }

            Console.WriteLine("******************* After order by country the name *******************");
            cities = cities.OrderBy(c => c.Country).ThenBy(n => n.Name).ToList<City>();
            foreach (var item2 in cities)
            {
                Console.WriteLine(item2.Name + " of " + item2.Country);
            }

            Console.Read();
        }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
