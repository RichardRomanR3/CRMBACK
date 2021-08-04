using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class EliminarTarea {
        public class Ejecuta : IRequest {
            public Guid TAREA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS.FindAsync (request.TAREA_Id);
                if (tarea == null) {
                    throw new System.Exception ("No se puede eliminar prro");

                }
                _context.Remove (tarea);
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;
                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}