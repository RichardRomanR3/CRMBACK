using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONEMPRESAS {
    public class EliminarEmpresa {
        public class Ejecuta : IRequest {
            public Guid EMPRESA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var empresa = await _context.Empresas.FindAsync (request.EMPRESA_Id);
                if (empresa == null) {
                    throw new System.Exception ("No se puede eliminar prro");

                }
                _context.Remove (empresa);
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;
                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}