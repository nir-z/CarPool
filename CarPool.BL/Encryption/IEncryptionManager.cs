using CarPool.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.Encryption
{
    public interface IEncryptionManager
    {

        JWT CreateJWT();

    }
}
