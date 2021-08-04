using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class UsuarioRolAgregar {
        public class Ejecuta : IRequest {
            public string UserName { get; set; }
            public string RolNombre { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (UserManager<Usuarios> userManager, RoleManager<Roles> roleManager) {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var rol = await _roleManager.FindByNameAsync (request.RolNombre);
                if (rol == null) {
                    throw new Exception ("EL ROL NO EXISTE");
                }
                var usuario = await _userManager.FindByNameAsync (request.UserName);
                if (usuario == null) {
                    throw new Exception ("NO EXISTE EL USUARIO");
                }
                var resultado = await _userManager.AddToRoleAsync (usuario, request.RolNombre);
                if (resultado.Succeeded) {
                    return Unit.Value;
                }
                throw new Exception ("NO SE PUDO AGREGAR EL ROL");
            }
        }
    }
}