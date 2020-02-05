using Avivatec.Padrao.Helpers.Dtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Avivatec.Padrao.Helpers.Helpers
{
    public class JwtHelper
    {
        private readonly JwtDto _jwtDto;

        public JwtHelper()
        {
            _jwtDto = new JwtDto
            {
                ChaveSecreta = Environment.GetEnvironmentVariable("ABBC-Jwt-ChaveSecreta"),
                EmissorDoToken = Environment.GetEnvironmentVariable("ABBC-Jwt-EmissorDoToken"),
                DestinatarioDoToken = Environment.GetEnvironmentVariable("ABBC-Jwt-DestinatarioDoToken"),
                DiasParaExpirar = Convert.ToInt32(Environment.GetEnvironmentVariable("ABBC-Jwt-DiasParaExpirar"))
            };
        }

        public string CriarToken(ClaimsIdentity claimsIdentity)
        {
            // configuração para o jwt
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            DateTime dataParaExpirar = DateTime.Now.AddDays(_jwtDto.DiasParaExpirar);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_jwtDto.ChaveSecreta));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // cria o jwt
            var token = tokenHandler.CreateJwtSecurityToken(
                issuer: _jwtDto.EmissorDoToken,
                audience: _jwtDto.DestinatarioDoToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: dataParaExpirar,
                signingCredentials: signingCredentials);

            // cria a chave para retornar
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public int RecuperaIdUsuario(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            return Convert.ToInt32(principal.Identity.Name);
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = "desativado",
                ValidAudience = "desativado",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtDto.ChaveSecreta))
            };
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}