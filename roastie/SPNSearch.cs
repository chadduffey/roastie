using System.Collections.Generic;
using System.DirectoryServices;

namespace roastie
{
    class SPNSearch
    {
        const string LDAP_QUERY_NO_COMPUTERS = "(&(servicePrincipalName=*/*)(!(objectClass=computer)))";
        const string LDAP_QUERY_WITH_COMPUTERS = "(servicePrincipalName=*/*)";

        internal static List<string> GatherSPNs(bool include_computers)
        {
            List<string> SPNs = new List<string>();

            string ldapfilter;
            if (include_computers)
            {
                ldapfilter = LDAP_QUERY_WITH_COMPUTERS;
            }
            else
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
    }
}
