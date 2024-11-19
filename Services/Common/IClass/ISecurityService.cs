using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.IClass
{
    public interface ISecurityService
    {
        string Encryption(string encrypt);
        string Decryption(string decrypt);
        
    }
}
