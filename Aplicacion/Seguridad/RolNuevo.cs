using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class RolNuevo {
        public class Ejecuta : IRequest {
            public string Nombre { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (RoleManager<Roles> roleManager) {
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var role = await _roleManager.FindByNameAsync (request.Nombre);
                if (role != null) {
                    throw new Exception ("el rol ya existe");
                }
                var nuevoId = Guid.NewGuid();
                var rolnuevo =new Roles{
                  Id=nuevoId.ToString(),
                  Name=request.Nombre
                };
                var resultado = await _roleManager.CreateAsync(rolnuevo);
                if (resultado.Succeeded) {
                    return Unit.Value;

                }
                throw new Exception ("No se puede registrar");
            }
        }
    }
}