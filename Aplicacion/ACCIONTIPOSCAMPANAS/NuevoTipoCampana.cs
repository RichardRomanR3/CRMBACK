using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTIPOSCAMPANAS {
    public class NuevoTipoCampana {

        public class Ejecuta : IRequest {
            public Guid TIPOCAMPANA_Id { get; set; }
            public int CODTIPOCAMPANA { get; set; }
            public string NUMTIPOCAMPANA { get; set; }
            public string DESCRITIPOCAMPANA { get; set; }
            public DateTime FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                Guid _tipocampanaId = Guid.NewGuid ();
                var tipocampana = new TIPOSCAMPANAS {
                    TIPOCAMPANA_Id = _tipocampanaId,
                    CODTIPOCAMPANA = request.CODTIPOCAMPANA,
                    NUMTIPOCAMPANA = request.NUMTIPOCAMPANA,
                    DESCRITIPOCAMPANA = request.DESCRITIPOCAMPANA,
                    FECGRA = DateTime.Now
                };
                _context.TIPOSCAMPANAS.Add (tipocampana);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");
            }
        }
    }
}