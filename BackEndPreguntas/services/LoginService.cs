using BackEndPreguntas.Commands;
using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using BackEndPreguntas.Middleware;
using BackEndPreguntas.Models;
using Npgsql;
using System;
using System.Data.Common;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackEndPreguntas.services
{
    public class LoginService : ILoginService
    {

        private readonly IJwtAuthManager jwtAuthManager;

        public LoginService(IJwtAuthManager jwtAuthManager)
        {
            this.jwtAuthManager = jwtAuthManager;
        }

        public AuthenticateResponse Login(Users users)
        {
            if (users != null)
            {
                String data = users.username + users.password;
                String hashBase64 = "";
                byte[] passwordEncoded = Encoding.ASCII.GetBytes(data);
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] sha1data = sha1.ComputeHash(passwordEncoded);
                    hashBase64 = Convert.ToBase64String(sha1data);
                }

                if (!String.IsNullOrEmpty(hashBase64))
                {
                    DbProviderFactory provider = NpgsqlFactory.Instance;
                    LoginCommand authentication = new LoginCommand(provider);
                    CommandResponse resp = new CommandResponse();
                    authentication.UsersRequest = new Users()
                    {
                        username = users.username,
                        password = hashBase64
                    };
                    authentication.Execute();
                    if (resp.Id >= 0)
                    {
                        users.id = Convert.ToInt32(resp.Id);
                        var jwtAuthResult = this.GenerateToken(users);
                        return new AuthenticateResponse(users, jwtAuthResult.AccessToken, jwtAuthResult.RefreshToken.TokenString);
                    }
                }
            }
            return null;
        }

        private JwtAuthResult GenerateToken(Users users)
        {
            var claims = new[]
                {
					 new Claim("id", users.id.ToString())
                };
            var jwtResult = this.jwtAuthManager.GenerateTokens(users.username, claims, DateTime.Now);
            return jwtResult;
        }
    }
}
