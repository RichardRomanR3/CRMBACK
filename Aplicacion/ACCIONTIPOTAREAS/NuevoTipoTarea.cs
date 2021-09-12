using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTIPOTAREAS {
    public class NuevoTipoTarea {
        public class Ejecuta : IRequest {
            public Guid TIPOTAREA_Id { get; set; }
            public int CODTIPOTAREA { get; set; }
            public string NUMTIPOTAREA { get; set; }

            public string DESCRITIPOTAREA { get; set; }
            public DateTime FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                Guid _tipotareaId = Guid.NewGuid ();
                var tipotarea = new TIPOSTAREAS {
                    TIPOTAREA_Id = _tipotareaId,
                    CODTIPOTAREA = request.CODTIPOTAREA,
                    NUMTIPOTAREA = request.NUMTIPOTAREA,
                    DESCRITIPOTAREA = request.DESCRITIPOTAREA,
                    FECGRA = DateTime.Now
                };
                _context.TIPOSTAREAS.Add (tipotarea);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");

            }
        }
    }
}