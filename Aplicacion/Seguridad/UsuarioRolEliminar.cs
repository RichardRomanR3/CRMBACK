using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class UsuarioRolEliminar {
        public class Ejecuta : IRequest {
            public string UserName { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly UserManager<Usuarios> _userManager;
            public Manejador (UserManager<Usuarios> userManager) {
                _userManager = userManager;   
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var user= await _userManager.FindByNameAsync(request.UserName);
                var roles = await _userManager.GetRolesAsync(user);
                   
                   var resultado = await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                if (resultado.Succeeded) {
                    return Unit.Value;

                }

                throw new Exception ("No se elimino");
            }
        }
    }
}