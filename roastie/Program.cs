using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace roastie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> SPNs = ListSPN();
            DisplaySPNs(SPNs);
            string choice;
            do {
                Console.Write("\n\nWould you like to roast a specific SPN [s] or all SPNs [a]? ([s or a] Default is specific [s] ): ");
                choice = Console.ReadLine();
            } while (choice != "a" && choice != "s");
        }

        static List<string> ListSPN()
        {
            List<string> SPNs = new List<string>();

            string ldapfilter = "(servicePrincipalName=*/*)";

            System.DirectoryServices.DirectoryEntry domain = new DirectoryEntry();
            System.DirectoryServices.DirectorySearcher searcher = new DirectorySearcher();
            searcher.SearchRoot = domain;
            searcher.PageSize = 1000;
            searcher.Filter = ldapfilter;

            //search
            SearchResultCollection results = searcher.FindAll();

            foreach (SearchResult result in results)
            {
                DirectoryEntry account = result.GetDirectoryEntry();

                foreach (string spn in account.Properties["servicePrincipalName"])
                {
                    SPNs.Add(spn);
                }

            }

            return SPNs;
        }

        static void DisplaySPNs(List<string> SPNs)
        {
            int counter = 1;
            foreach (string item in SPNs)
            {
                Console.WriteLine("{0}: {1}", counter, item);
                counter++;
            }
        }

    }
}
