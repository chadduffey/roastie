using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roastie
{
    public class Menus
    {
        public static bool MenuMain()
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

        public static void displayBanner()
        {
            string banner = @"
 _____                 _   _      
|  __ \               | | (_)     
| |__) |___   __ _ ___| |_ _  ___ 
|  _  // _ \ / _` / __| __| |/ _ \
| | \ \ (_) | (_| \__ \ |_| |  __/
|_|  \_\___/ \__,_|___/\__|_|\___|";
            Console.WriteLine(banner);
        }

        public static int MenuSPNtoRoast()
        {
            string choice;
            do
            {
                Console.Write("\n\nWhich SPN should we fire up? ('0' for ALL): ");
                choice = Console.ReadLine();
                Console.Clear();
            } while (choice != "a" && choice != "s");
            return 1;
        }


    }
}
