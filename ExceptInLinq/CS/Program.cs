using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<City>
                        {
                            new City {Country = "Vietnam", Name = "Ha Noi", isRead=false,CreatedBy="quachnguyen"},
                            new City {Country = "USA", Name = "New York", isRead=false,CreatedBy="code2code"},
                            new City {Country = "USA", Name = "Sri lanka", isRead=false,CreatedBy="quachnguyen"},
                            new City {Country = "Japan", Name = "Tokyo", isRead=true,CreatedBy="quachnguyen"},
                            new City {Country = "Spain", Name = "Milan", isRead=false,CreatedBy="code2code"},
                            new City {Country = "Spain", Name = "Real Madrid", isRead=true,CreatedBy="code2code"},
                            new City {Country = "Spain", Name = "Barcelona", isRead=true,CreatedBy="quachnguyen"},
                            new City {Country = "Netherland", Name = "Amsterdam", isRead=false,CreatedBy="quachnguyen"},
                            new City {Country = "Vietnam", Name = "Ho Chi Minh", isRead=false,CreatedBy="quachnguyen"},
                        };

            var myCities = cities.Where(c => c.CreatedBy == "quachnguyen");

            var result = cities.Where(c => c.isRead == false).Except(myCities);

            foreach (var item in result)
            {
                Console.WriteLine(item.Country + " " + item.Name + " " + item.CreatedBy + " " + item.isRead);
            }
            Console.Read();
        }
    }
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public bool isRead { get; set; }
        public string CreatedBy { get; set; }
    }
}
