using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplicacion.Contratos;
using Dominio;
using Microsoft.IdentityModel.Tokens;

namespace Seguridad {
    public class JwtGenerador : IJwtGenerador {
        public string CrearToken (Usuarios usuario, List<string> roles) {
            var claims = new List<Claim> {
                new Claim (JwtRegisteredClaimNames.NameId, usuario.UserName)
            };
            if (roles != null) {
                foreach (var rol in roles) {
                    claims.Add (new Claim (ClaimTypes.Role, rol));
                }
            }
            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("Tileria palabra secreta"));
            var credenciales = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescripcion = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (claims),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = credenciales
            };
            var tokenManejador = new JwtSecurityTokenHandler ();
            var token = tokenManejador.CreateToken (TokenDescripcion);
            return tokenManejador.WriteToken (token);

        }
    }
}