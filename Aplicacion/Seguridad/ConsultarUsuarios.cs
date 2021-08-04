using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class ConsultarUsuarios {
        public class Ejecuta : IRequest<List<Usuarios>> {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<Usuarios>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<List<Usuarios>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var usuarios = await _context.Users.ToListAsync ();
                return usuarios;
            }
        }
    }
}