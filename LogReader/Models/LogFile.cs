using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogReader.Models
{
    public class LogFile
    {
        public LogFile()
        {
        }

        private readonly string _ipPattern = @"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))";
        private readonly string _requestType = "GET";
        private readonly string _portNumber = "80";


        private List<string> _ipAddressList;
        public List<IPAddress> CollectGetRequestData(List<string> logLines)
        {
            Regex r = new Regex(_ipPattern);
            var ipAddresses = new List<IPAddress>();
            string ip = string.Empty;

            //extract all IP's with GET request matching port 80
            foreach (string line in logLines)
            {
                if(line.Contains(_requestType) && line.Contains(_portNumber))
                {
                    Match match = r.Match(line);
                    if (!string.IsNullOrEmpty(match.Value))
                    {
                        //see if ip address exists; add ip or increment count
                        if (ipAddresses.Count > 0 && ipAddresses.Where(i => i.IP == ip).Any())
                        {
                            int index = ipAddresses.FindIndex(i => i.IP == ip);
                            ipAddresses[index].IpGetRequestCount += 1;
                        }
                        else
                        {
                            IPAddress ipAddress = new IPAddress();
                            ipAddress.IP = ip;
                            ipAddress.IpGetRequestCount = 1;
                            ipAddresses.Add(ipAddress);
                        }
                    }
                }

            }

            return ipAddresses;   
        }

        public void GenerateCSVReport()
        {

        }
    }
}
