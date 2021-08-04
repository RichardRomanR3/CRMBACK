using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class ConsultaClientesPorId {
        public class ClienteUnico : IRequest<CLIENTES> {
            public Guid CLIENTE_Id { get; set; }

        }
        public class Manejador : IRequestHandler<ClienteUnico, CLIENTES> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<CLIENTES> Handle (ClienteUnico request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                return cliente;
            }
        }
    }
}