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
            bool mode = Menus.MenuMain();

            List<string> SPNs = ListSPN(mode);

            DisplaySPNs(SPNs);

            int target = Menus.MenuSPNtoRoast();
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

        

    }
}
