using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LogReader.Models;

namespace LogReader
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"Data\\access.log";
            try
            {
                var accessLogLines = File.ReadAllLines(path);

                //use LogFile object to extract data, sort it, and generate report
                LogFile logFile = new LogFile();
                var ipAddresses = logFile.CollectGetRequestData(accessLogLines);

                ipAddresses = logFile.SortIPAddressList(ipAddresses);
                logFile.GenerateCSVReport(ipAddresses);
            }
            catch (Exception e)
            {
                //show the error to user
                Console.WriteLine("Sorry ran in to an exception :(, but here's more info:");
                string errorLogLine = string.Format("{0} {1} {2}", e.Message, e.InnerException, e.StackTrace);
                Console.WriteLine(errorLogLine);
            }
            Console.WriteLine("All done. Please press any key to exit the program.");
            Console.ReadKey();

        }
    }
}
