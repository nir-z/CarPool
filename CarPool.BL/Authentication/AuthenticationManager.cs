using CarPool.BL.Encryption;
using CarPool.Models.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BL.Authentication
{
    public class AuthenticationManager: IAuthenticationManager
    {
        private readonly IEncryptionManager _encryptionManager;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _iconfiguration;



        public AuthenticationManager(IConfiguration iconfiguration, IEncryptionManager encryptionManager)
        {
            _iconfiguration = iconfiguration;
            _encryptionManager = encryptionManager;
        }


		public JWT Authenticate(LoginRequest loginRequest)
		{
            return _encryptionManager.CreateJWT();
        }
	}
}
