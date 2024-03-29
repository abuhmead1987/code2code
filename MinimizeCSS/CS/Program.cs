﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string minstyle = RemoveWhiteSpaceFromStylesheets(File.ReadAllText(@"..\..\style.css"));
            File.WriteAllText(@"..\..\style-min.css", minstyle);
            Console.WriteLine("Done!");
            Console.Read();
        }

        public static string RemoveWhiteSpaceFromStylesheets(string body)
        {
            body = Regex.Replace(body, @"[a-zA-Z]+#", "#");
            body = Regex.Replace(body, @"[\n\r]+\s*", string.Empty);
            body = Regex.Replace(body, @"\s+", " ");
            body = Regex.Replace(body, @"\s?([:,;{}])\s?", "$1");
            body = body.Replace(";}", "}");
            body = Regex.Replace(body, @"([\s:]0)(px|pt|%|em)", "$1");
            // Remove comments from CSS
            body = Regex.Replace(body, @"/\*[\d\D]*?\*/", string.Empty);
            return body;
        }
    }
}
