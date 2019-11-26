using System;
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
            Console.WriteLine("SPN: {0}", t.ServicePrincipalName);
            Console.WriteLine("Valid From: {0}", t.ValidFrom);
            Console.WriteLine("Valid To: {0}", t.ValidTo);
            Console.WriteLine("Key Size: {0}", t.SecurityKey.KeySize);
        }
        
    }
}
