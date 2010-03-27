using System;
using System.Diagnostics;
using System.Threading;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Thread.Sleep(1000);
            sw.Stop();
            string timeElap = sw.ElapsedMilliseconds.ToString();
            Console.WriteLine(timeElap);
            Console.Read();
            sw.Restart();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());
            Console.ReadKey();
        }
    }
}
