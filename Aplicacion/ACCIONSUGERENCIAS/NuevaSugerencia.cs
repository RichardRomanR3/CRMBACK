using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONSUGERENCIAS {
    public class NuevaSugerencia {
        public class Ejecuta : IRequest {
            public string contenido { get; set; }
            public Guid? clienteId { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var sugerenciaId = Guid.NewGuid ();
                var sugerencia = new SUGERENCIAS {
                    Id = sugerenciaId,
                    sugerencia = request.contenido,
                    ClienteId = request.clienteId,
                    FECGRA = DateTime.Now
                };
                _context.SUGERENCIAS.Add (sugerencia);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");
            }
        }
    }
}