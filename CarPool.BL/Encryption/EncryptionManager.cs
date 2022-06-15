using CarPool.Models.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarPool.BL.Encryption
{
    public class EncryptionManager: IEncryptionManager
    {

        private readonly IConfiguration _iconfiguration;

        private const int SESSION_EXPIRATION_TIME = 10;

        public EncryptionManager(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public JWT CreateJWT()
        {
            using RSA rsa = RSA.Create();

            rsa.ImportRSAPrivateKey( 
                source: Convert.FromBase64String(_iconfiguration["JWT:PrivateKey"]),
                bytesRead: out int _); // Discard the out variable 

            var signingCredentials = new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256 
            );

            DateTime jwtDate = DateTime.Now;

            var jwt = new JwtSecurityToken(
                audience: _iconfiguration["JWT:Audience"],
                issuer: _iconfiguration["JWT:Issuer"],
                claims: new Claim[] { new Claim(ClaimTypes.NameIdentifier, "some-username") },
                notBefore: jwtDate,
                expires: jwtDate.AddMinutes(SESSION_EXPIRATION_TIME),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JWT
            {
                Token = token
            };
        }


    }
}
