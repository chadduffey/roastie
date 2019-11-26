using System;
using System.Reflection;
using System.Security.Principal;

namespace roastie
{
    class SPNRequest
    {
        public static void RequestAuth()
        {
            System.IdentityModel.Tokens.KerberosRequestorSecurityToken ticket =
                new System.IdentityModel.Tokens.KerberosRequestorSecurityToken
                ("MSSQLSVC/exchange.chadduffey.com", TokenImpersonationLevel.Impersonation, null, Guid.NewGuid().ToString());

            DisplayTicket(ticket);

        }

        private static void DisplayTicket(System.IdentityModel.Tokens.KerberosRequestorSecurityToken t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t[#] Got it.");
            Console.ResetColor();
            Console.WriteLine("\tSPN: {0}", t.ServicePrincipalName);
            Console.WriteLine("\tValid From: {0}", t.ValidFrom);
            Console.WriteLine("\tValid To: {0}", t.ValidTo);
            Console.WriteLine("\tKey Size: {0}", t.SecurityKey.KeySize);

        }
        
    }
}
