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
            Console.WriteLine("\t[#] SPN: {0}", t.ServicePrincipalName);
            Console.WriteLine("\t[#] Valid From: {0}", t.ValidFrom);
            Console.WriteLine("\t[#] Valid To: {0}", t.ValidTo);
            Console.WriteLine("\t[#] Key Size: {0}", t.SecurityKey.KeySize);

        }
        
    }
}
