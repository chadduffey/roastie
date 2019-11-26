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

        const string LDAP_QUERY_NO_COMPUTERS      = "(&(servicePrincipalName=*/*)(!(objectClass=computer)))";
        const string LDAP_QUERY_WITH_COMPUTERS    = "(servicePrincipalName=*/*)";

        static void Main(string[] args)
        {
            bool mode = MainMenu();

            List<string> SPNs = ListSPN(mode);

            DisplaySPNs(SPNs);

            int target = MenuSPNtoRoast();
        }

        static bool MainMenu()
        {
            displayBanner();
            Console.Write("\n\nShould we include computer account SPNs? [y/N]: ");
            string choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                Console.Clear();
                Console.WriteLine("[*] Searching for User and Computer SPN's: ");
                return true;
            }
            Console.Clear();
            Console.WriteLine("[*] Searching for User SPN's: ");
            return false;
        }

        static int MenuSPNtoRoast()
        {
            string choice;
            do
            {
                Console.Write("\n\nWould you like to roast a specific SPN [s] or all SPNs [a]?: ");
                choice = Console.ReadLine();
                Console.Clear();
            } while (choice != "a" && choice != "s");
            return 1;
        }

        static List<string> ListSPN(bool include_computers)
        {
            List<string> SPNs = new List<string>();

            string ldapfilter;
            if (include_computers)
            {
                ldapfilter = LDAP_QUERY_WITH_COMPUTERS;
            } else
            {
                ldapfilter = LDAP_QUERY_NO_COMPUTERS;
            }
            

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

        static void displayBanner()
        {
            string banner = @" _____                 _   _      
|  __ \               | | (_)     
| |__) |___   __ _ ___| |_ _  ___ 
|  _  // _ \ / _` / __| __| |/ _ \
| | \ \ (_) | (_| \__ \ |_| |  __/
|_|  \_\___/ \__,_|___/\__|_|\___|";
            Console.WriteLine(banner);
        }

    }
}
