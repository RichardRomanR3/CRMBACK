using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCAMPANAS {
    public class NuevaCampana {
        public class Ejecuta : IRequest {
            public Guid CAMPANA_Id { get; set; }
            public int CODCAMPANA { get; set; }
            public string NUMCAMPANA { get; set; }
            public string DESCRICAMPANA { get; set; }
            public string ESTADOCAMPANA { get; set; }
            public string OBJETIVOS { get; set; }

            public decimal PRESUPUESTO { get; set; }
            public string GEOGRAFIA { get; set; }
            public string EMPRESACONTRATADA { get; set; }
            public DateTime FECGRA { get; set; }
            public Guid TIPOCAMPANA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {

                var _tipocampanaId = await _context.TIPOSCAMPANAS.FindAsync (request.TIPOCAMPANA_Id);
                Guid _campanaId = Guid.NewGuid ();
                var campana = new CAMPANAS {
                    CAMPANA_Id = _campanaId,
                    CODCAMPANA = request.CODCAMPANA,
                    NUMCAMPANA = request.NUMCAMPANA,
                    DESCRICAMPANA = request.DESCRICAMPANA,
                    ESTADOCAMPANA = request.ESTADOCAMPANA,
                    FECGRA = DateTime.Now,
                    TIPOSCAMPANAS = _tipocampanaId,
                    OBJETIVOS = request.OBJETIVOS,
                    PRESUPUESTO = request.PRESUPUESTO,
                    GEOGRAFIA = request.GEOGRAFIA,
                    EMPRESACONTRATADA = request.EMPRESACONTRATADA
                };
                _context.CAMPANAS.Add (campana);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");
            }
        }
    }
}