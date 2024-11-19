
using Services.Common.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Class
{
    public class SecurityService : ISecurityService
    {
        private readonly Security _security;
        public SecurityService(Security security)
        {
            _security = security;
        }

        public string Encryption(string encrypt)
        {
            return _security.EncryptedValue(encrypt); 
        }

        public string Decryption(string decrypt)
        {
            Console.WriteLine(_security.DecryptedValue(decrypt));
            return _security.DecryptedValue(decrypt);  
        }

    }
}
