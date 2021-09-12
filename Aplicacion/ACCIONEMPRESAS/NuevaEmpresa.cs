using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONEMPRESAS {
    public class NuevaEmpresa {
        public class Ejecuta : IRequest {
            public int CODEMPRESA { get; set; }
            public string NUMEMPRESA { get; set; }
            public string DESCRIEMPRESA { get; set; }

            public DateTime FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public  Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                /*var _empresaId = Guid.NewGuid ();
                var empresa = new EMPRESAS {
                    EMPRESAS_Id = _empresaId,
                    CODEMPRESA = request.CODEMPRESA,
                    NUMEMPRESA = request.NUMEMPRESA,
                    DESCRIEMPRESA = request.DESCRIEMPRESA,
                    FECGRA = DateTime.Now
                };
                _context.EMPRESAS.Add (empresa);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }*/
                throw new Exception ("No se guardaron los datos");
            }
        }
    }
}