using System.Linq;
using System.Security.Claims;
using Aplicacion.Contratos;
using Microsoft.AspNetCore.Http;

namespace Seguridad {
    public class UsuarioSesion : IUsuarioSesion {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsuarioSesion (IHttpContextAccessor httpContextAccesor) {
            _httpContextAccessor = httpContextAccesor;

        }
        public string ObtenerUsuarioSesion () {
            var UserName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault (x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return UserName;
        }
    }
}