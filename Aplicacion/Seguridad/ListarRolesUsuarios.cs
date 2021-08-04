using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class ListarRolesUsuarios {
        public class Ejecuta : IRequest<List<string>> {
            public string UserName { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<string>> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (UserManager<Usuarios> userManager, RoleManager<Roles> roleManager) {
                _userManager = userManager;
                _roleManager = roleManager;

            }
            public async Task<List<string>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var usuario = await _userManager.FindByNameAsync (request.UserName);
                if (usuario == null) {
                    throw new Exception ("EL USUARIO NO EXISTE");
                }
                var resultado = await _userManager.GetRolesAsync (usuario);
                return new List<string> (resultado);
            }
        }

    }
}