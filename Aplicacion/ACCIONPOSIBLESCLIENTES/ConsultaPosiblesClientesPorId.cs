using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONPOSIBLESCLIENTES {
    public class ConsultaPosiblesClientesPorId {
        public class PosibleClienteUnico : IRequest<POSIBLESCLIENTES> {
            public Guid POSIBLECLIENTE_Id { get; set; }

        }
        public class Manejador : IRequestHandler<PosibleClienteUnico, POSIBLESCLIENTES> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<POSIBLESCLIENTES> Handle (PosibleClienteUnico request, CancellationToken cancellationToken) {
                var posiblecliente = await _context.POSIBLESCLIENTES.FindAsync (request.POSIBLECLIENTE_Id);
                return posiblecliente;
            }
        }
    }
}