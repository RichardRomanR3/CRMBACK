using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONPOSIBLESCLIENTES {
    public class ConsultaPosiblesClientes {
        public class ListaPosiblesClientes : IRequest<List<POSIBLESCLIENTES>> {
            public string USUARIO { get; set; }

        }
        public class Manejador : IRequestHandler<ListaPosiblesClientes, List<POSIBLESCLIENTES>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }
            public async Task<List<POSIBLESCLIENTES>> Handle (ListaPosiblesClientes request, CancellationToken cancellationToken) {
                var posiblesclientes = await _context.POSIBLESCLIENTES.Where (x => x.UsuarioId == request.USUARIO).OrderBy (x => x.FECGRA).ToListAsync ();
                return posiblesclientes;
            }
        }
    }
}