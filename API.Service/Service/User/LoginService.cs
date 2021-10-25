using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Domain.Dtos.Login;
using Domain.Entities;
using Domain.Interfaces.Services.User;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Service.Service.User
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        private SignConfigurations _signingConfigurations;

        private TokenConfigurations _tokenConfigurations;

        private IConfiguration _configuration;

        public LoginService(IConfiguration configuration, IUserRepository repository, SignConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseUser = new UserEntity();

            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                baseUser = await _repository.FindByLogin(login.Email);

                if (baseUser == null)
                    return new JsonObject("{ authenticated: false, message: Falha ao autenticar }");

                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email)
                        }



                        );

                    DateTime createData = DateTime.Now;
                    DateTime expirationDate = createData + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handle = new JwtSecurityTokenHandler();

                    string token = CreateToken(identity, createData, expirationDate, handle);

                    return SuccessObject(createData, expirationDate, token, baseUser);
                }
            }
            else
                return null;

        }

        private object SuccessObject(DateTime createData, DateTime expirationDate, string token, UserEntity user)
        {
            return new {
                authenticated = true,
                created = createData.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationDate = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuário logado com sucesso"
            };
          
        }

        private string CreateToken(ClaimsIdentity claimsIdentity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            var securityToken = jwtSecurityTokenHandler.CreateToken(
                new SecurityTokenDescriptor {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = claimsIdentity,
                    NotBefore = createDate,
                    Expires = expirationDate
                });

            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
