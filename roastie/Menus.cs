using System;
using System.Collections.Generic;

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

        public static int MenuSPNtoRoast(int max_spn)
        {
            string str_choice;
            int int_choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[?] Which SPN should we fire up? ('0' for ALL): ");
                str_choice = Console.ReadLine();
                Console.ResetColor();
            } while ((!int.TryParse(str_choice, out int_choice)) || (int_choice < 0) || (int_choice > max_spn));

            return int_choice;
        }

        public static int DisplaySPNs(List<string> SPNs)
        {
            int counter = 1;
            foreach (string item in SPNs)
            {
                Console.WriteLine("\t[#] {0}: {1}", counter, item);
                counter++;
            }
            return counter -1;
        }


    }
}
