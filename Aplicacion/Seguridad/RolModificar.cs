using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class RolModificar
    {
        public class Ejecuta : IRequest {

            public string Id { set; get; }
            public string Nombre { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (RoleManager<Roles> roleManager) {
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                
                var rolex = await _roleManager.FindByIdAsync(request.Id);
                
                if (rolex == null) {
                    throw new Exception ("El rol no existe");
                }

                var role = await _roleManager.FindByNameAsync (request.Nombre);

                if(role != null){
                    throw new Exception("Ya existe un rol con ese nombre");
                }

                //var resultado = await _roleManager.CreateAsync (new IdentityRole (request.Nombre));

                rolex.Name = request.Nombre;

                var resultado = await _roleManager.UpdateAsync(rolex);
                
                if (resultado.Succeeded) {
                    return Unit.Value;
                }

                throw new Exception ("No se pudo actualizar el Rol");
            }
        }
    }
}