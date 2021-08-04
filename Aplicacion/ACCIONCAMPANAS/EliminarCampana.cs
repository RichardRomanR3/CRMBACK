using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCAMPANAS {
    public class EliminarCampana {
        public class Ejecuta : IRequest {
            public Guid CAMPANA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var campana = await _context.CAMPANAS.FindAsync (request.CAMPANA_Id);
                if (campana == null) {
                    throw new System.Exception ("No se puede eliminar prro");

                }
                _context.Remove (campana);
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;

                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}