using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class ConsultarClientePorCI {
        public class ClienteUnico : IRequest<List<CLIENTES>> {
            public string CI { get; set; } 

        }
        public class Manejador : IRequestHandler<ClienteUnico, List<CLIENTES>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<List<CLIENTES>> Handle (ClienteUnico request, CancellationToken cancellationToken) {
                var lista = await _context.CLIENTES.Where (x => x.CI == request.CI || x.RUC == request.CI).ToListAsync ();
                return lista;
            }
        }
    }
}