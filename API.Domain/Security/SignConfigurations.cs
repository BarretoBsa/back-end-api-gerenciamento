using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Security
{
    public class SignConfigurations
    {
        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public SignConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSsaPssSha256Signature);
        }


    }
}
