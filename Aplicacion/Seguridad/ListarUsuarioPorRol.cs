using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad {
    public class ListarUsuarioPorRol {
        public class Ejecuta : IRequest<List<Usuarios>> {
            public string RoleName { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<Usuarios>> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly RoleManager<Roles> _roleManager;
            public Manejador (UserManager<Usuarios> userManager, RoleManager<Roles> roleManager) {
                _userManager = userManager;
                _roleManager = roleManager;

            }

            public async Task<List<Usuarios>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var lista = await _userManager.GetUsersInRoleAsync (request.RoleName);
                return lista as List<Usuarios>;
            }
        }

    }
}