using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONEMPRESAS {
    public class ConsultaEmpresas {
        public class ListaEmpresas : IRequest<List<Empresas>> {

        }
        public class Manejador : IRequestHandler<ListaEmpresas, List<Empresas>> {

            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<List<Empresas>> Handle (ListaEmpresas request, CancellationToken cancellationToken) {
                var empresas = await _context.Empresas.ToListAsync ();
                return empresas;
            }
        }
    }
}