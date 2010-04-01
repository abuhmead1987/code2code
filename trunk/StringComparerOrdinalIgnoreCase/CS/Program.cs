using System;
using System.Linq;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = { "NeonQuach", "QuachNguyen" };
            if (name.Contains("neonquach",StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("compare with no case-sensitive, neonquach exits in name array");
            }
            else if (name.Contains("neonquach"))
            {
                Console.WriteLine("compare with case-sensitive");
            }
            Console.Read();
        }
    }
}
