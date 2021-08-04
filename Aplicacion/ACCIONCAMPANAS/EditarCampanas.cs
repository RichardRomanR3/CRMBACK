using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCAMPANAS {
    public class EditarCampanas {
        public class Ejecuta : IRequest {
            public Guid CAMPANA_Id { get; set; }
            public int CODCAMPANA { get; set; }
            public string NUMCAMPANA { get; set; }
            public string DESCRICAMPANA { get; set; }
            public string ESTADOCAMPANA { get; set; }
            public string OBJETIVOS { get; set; }

            public decimal? PRESUPUESTO { get; set; }
            public string GEOGRAFIA { get; set; }
            public string EMPRESACONTRATADA { get; set; }
            public DateTime? FECGRA { get; set; }
            public Guid TIPOCAMPANA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var campana = await _context.CAMPANAS.FindAsync(request.CAMPANA_Id);
                if (campana == null) {
                    throw new Exception ("El curso no existe prro");
                }
                var _tipocampanaId = await _context.TIPOSCAMPANAS.FindAsync (request.TIPOCAMPANA_Id);

                campana.NUMCAMPANA = request.NUMCAMPANA ?? campana.NUMCAMPANA;
                campana.DESCRICAMPANA = request.DESCRICAMPANA ?? campana.DESCRICAMPANA;
                campana.ESTADOCAMPANA = request.ESTADOCAMPANA ?? campana.ESTADOCAMPANA;
                campana.TIPOSCAMPANAS = _tipocampanaId ?? campana.TIPOSCAMPANAS;
                campana.OBJETIVOS = request.OBJETIVOS ?? campana.OBJETIVOS;
                campana.PRESUPUESTO = request.PRESUPUESTO ?? campana.PRESUPUESTO;
                campana.GEOGRAFIA = request.GEOGRAFIA ?? campana.GEOGRAFIA;
                campana.EMPRESACONTRATADA = request.EMPRESACONTRATADA ?? campana.EMPRESACONTRATADA;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");

            }
        }
    }
}