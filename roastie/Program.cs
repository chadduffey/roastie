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
            List<string> SPNS = ListSPN();
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
    }
}
