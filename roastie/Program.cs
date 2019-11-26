using System;
using System.Collections.Generic;

// this whole thing is because of the work here: https://github.com/nidem/kerberoast by Tim Medin. 
// i'm just trying to learn some C# :) 

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

            SPNRequest.RequestAuth();
            Console.ReadKey();

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
