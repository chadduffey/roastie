using System;

namespace roastie
{
    public class Menus
    {
        public static bool MenuMain()
        {
            DisplayBanner();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\n[?] Should we include computer account SPNs? [y/N]: ");
            Console.ResetColor();
            string choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                Console.Clear();
                Console.WriteLine("[*] Searching for User and Computer SPN's: ");
                return true;
            }
            Console.WriteLine("[*] Searching for User SPN's: ");
            return false;
        }

        public static void DisplayBanner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string banner = @"
 _____                 _   _      
|  __ \               | | (_)     
| |__) |___   __ _ ___| |_ _  ___ 
|  _  // _ \ / _` / __| __| |/ _ \
| | \ \ (_) | (_| \__ \ |_| |  __/
|_|  \_\___/ \__,_|___/\__|_|\___|";
            Console.WriteLine(banner);
            Console.ResetColor();
        }

        public static int MenuSPNtoRoast()
        {
            string choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[?] Which SPN should we fire up? ('0' for ALL): ");
                choice = Console.ReadLine();
                Console.ResetColor();
            } while (choice != "a" && choice != "s");
            return 1;
        }


    }
}
