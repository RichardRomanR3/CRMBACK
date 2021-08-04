using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTIPOTAREAS {
    public class EditarTiposTareas {
        public class Ejecuta : IRequest {
            public Guid TIPOTAREA_Id { get; set; }
            public int CODTIPOTAREA { get; set; }
            public string NUMTIPOTAREA { get; set; }

            public string DESCRITIPOTAREA { get; set; }
            public DateTime? FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var tipotarea = await _context.TIPOSTAREAS.FindAsync (request.TIPOTAREA_Id);

                if (tipotarea == null) {
                    throw new Exception ("EL TIPO TAREA NO existe prro");
                }

                var utilizadoEnOtro = await _context.TIPOSTAREAS.Where(x => x.CODTIPOTAREA == request.CODTIPOTAREA).FirstOrDefaultAsync();

                if(utilizadoEnOtro!=null){
                    throw new Exception("Codigo ya se utiliza en otro Tipo de Tarea");
                }

                if(request.CODTIPOTAREA!=0){
                    tipotarea.CODTIPOTAREA = request.CODTIPOTAREA;
                }
                
                tipotarea.DESCRITIPOTAREA = request.DESCRITIPOTAREA ?? tipotarea.DESCRITIPOTAREA;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}