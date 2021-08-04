using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class EliminarRed {
        public class Ejecuta : IRequest {
            public Guid RED_Id { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var red = await _context.REDES_CLIENTES.FindAsync (request.RED_Id);
                if (red == null) {
                    throw new System.Exception ("No se puede eliminar prro");

                }
                _context.Remove (red);
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;
                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}