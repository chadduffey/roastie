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
            int SPNCount = Menus.DisplaySPNs(SPNs);    
            int target = Menus.MenuSPNtoRoast(SPNCount);
            SPNRequest.RequestAuth(SPNs[target -1]);
            TicketExport.ExportTickets();
            Console.ReadKey();

        }        

    }
}
