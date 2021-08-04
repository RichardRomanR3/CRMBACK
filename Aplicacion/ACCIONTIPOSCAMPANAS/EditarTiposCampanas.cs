using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTIPOSCAMPANAS {
    public class EditarTiposCampanas {
        public class Ejecuta : IRequest {
            public Guid TIPOCAMPANA_Id { get; set; }
            public int CODTIPOCAMPANA { get; set; }
            public string NUMTIPOCAMPANA { get; set; }
            public string DESCRITIPOCAMPANA { get; set; }
            public DateTime? FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var tipocampana = await _context.TIPOSCAMPANAS.FindAsync (request.TIPOCAMPANA_Id);

                if (tipocampana == null) {
                    throw new Exception ("EL TIPO CAMPANA NO existe prro");
                }

                var utilizadoEnOtro = await _context.TIPOSCAMPANAS.Where(x => x.CODTIPOCAMPANA == request.CODTIPOCAMPANA).FirstOrDefaultAsync();

                if(utilizadoEnOtro!=null){
                    throw new Exception("Codigo ya se utiliza en otro Tipo de Campana");
                }

                if(request.CODTIPOCAMPANA!=0){
                    tipocampana.CODTIPOCAMPANA = request.CODTIPOCAMPANA;
                }
                
                tipocampana.DESCRITIPOCAMPANA = request.DESCRITIPOCAMPANA ?? tipocampana.DESCRITIPOCAMPANA;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}