using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONEMPRESAS {
    public class EditarEmpresas {
        public class Ejecuta : IRequest {
            public Guid EMPRESA_Id { get; set; }
            public int CODEMPRESA { get; set; }
            public string NUMEMPRESA { get; set; }
            public string DESCRIEMPRESA { get; set; }

            public DateTime? FECGRA { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
               /* var empresa = await _context.Empresas.FindAsync (request.EMPRESA_Id);
                if (empresa == null) {
                    throw new Exception ("la empresa no existe prro");
                }
                empresa.NUMEMPRESA = request.NUMEMPRESA ?? empresa.NUMEMPRESA;
                empresa.DESCRIEMPRESA = request.DESCRIEMPRESA ?? empresa.DESCRIEMPRESA;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;*/
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}