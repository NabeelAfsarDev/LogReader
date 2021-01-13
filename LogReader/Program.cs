using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LogReader
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"Data\\access.log";
            var logFile = File.ReadAllLines(path);
            string pattern = @"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))";
            Regex r = new Regex(pattern);
            string input = File.ReadAllText(path);
            MatchCollection matches = r.Matches(input);
            foreach (Match match in matches)
                Console.WriteLine(match.Value);

            //List<string> logFileList = new List<string>(logFile);
            //foreach(var line in logFileList)
            //{
            //    Console.WriteLine(line);
            //}
            Console.ReadKey();
        }
    }
}
