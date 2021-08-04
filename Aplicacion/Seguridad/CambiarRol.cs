using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class CambiarRol {
        public class Ejecuta : IRequest {

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var rol = await _context.Roles.Where (x => x.Name == "VENDEDOR").FirstOrDefaultAsync ();

                if (rol != null) {
                    rol.Name = "VENDEDORASIG";
                } else {
                    rol = await _context.Roles.Where (x => x.Name == "VENDEDORASIG").FirstAsync ();
                    rol.Name = "VENDEDOR";
                }
                var resultadoUpdate = await _context.SaveChangesAsync ();
                if (resultadoUpdate > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se cambio");
            }
        }
    }
}