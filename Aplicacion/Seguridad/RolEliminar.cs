using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class RolEliminar {
        public class Ejecuta : IRequest {
            public Guid Id{set;get;}
            public string Nombre { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (RoleManager<Roles> roleManager) {
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var role = await _roleManager.FindByIdAsync (request.Id.ToString());

                if (role == null) {
                    throw new Exception ("No existe el rol");
                }

                var resultado = await _roleManager.DeleteAsync (role);
                if (resultado.Succeeded) {
                    return Unit.Value;

                }

                throw new Exception ("No se elimino");
            }
        }
    }
}