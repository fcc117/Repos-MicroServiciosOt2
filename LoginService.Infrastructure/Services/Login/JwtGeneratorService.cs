using LoginService.Aplication.Interfaces.Login;
using LoginService.Domain.Entities.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Entities.Token;

namespace LoginService.Infrastructure.Services.Login
{
    public class JwtGeneratorService : IJwtGeneratorService
    {
        private readonly EntJwt _jwtOpc; 
        public JwtGeneratorService(IOptions<EntJwt> jwtOpc)
        {
            _jwtOpc = jwtOpc.Value;
        }
        public string generaToken(EntUsuario usuario)
        {

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.fnNumeroEmpleado.ToString()),
            new Claim(ClaimTypes.Name, usuario.fcNombre),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtOpc.Issuer),
            new Claim(JwtRegisteredClaimNames.Aud, _jwtOpc.Audience)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOpc.Key)
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow.AddMinutes(-1), 
                Expires = DateTime.UtcNow.AddMinutes(1),//_jwtOpc.ExpiresMinutes
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        public string generaRefreshToken(int fcNumeroEmpleado)
        {
            var RefreshTokenExpiresDays = _jwtOpc.RefreshTokenExpiresDays;
            var refreshToken = new EntRefreshToken { 
                Token = Guid.NewGuid().ToString(),
                Expiry = DateTime.UtcNow.AddDays(RefreshTokenExpiresDays),
                UserId = fcNumeroEmpleado
            };
           return refreshToken.Token;
        }

    }
}
