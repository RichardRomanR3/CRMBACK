using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class RolLista {
        public class Ejecuta : IRequest<List<Roles>> {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<Roles>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<List<Roles>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var roles = await _context.Roles.ToListAsync ();
                return roles;
            }
        }
    }
}