using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTIPOTAREAS {
    public class EliminarTipoTarea {
        public class Ejecuta : IRequest {
            public Guid TIPOTAREA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var tipotarea = await _context.TIPOSTAREAS.FindAsync (request.TIPOTAREA_Id);
                if (tipotarea == null) {
                    throw new System.Exception ("No se puede eliminar prro");

                }
                _context.Remove (tipotarea);
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;
                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}