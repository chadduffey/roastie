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
            bool mode = Menus.MenuMain();

            List<string> SPNs = SPNSearch.GatherSPNs(mode);

            DisplaySPNs(SPNs);

            int target = Menus.MenuSPNtoRoast();
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
