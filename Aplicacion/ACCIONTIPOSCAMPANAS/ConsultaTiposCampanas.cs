using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTIPOSCAMPANAS {
    public class ConsultaTiposCampanas {
        public class ListaTiposCampanas : IRequest<List<TIPOSCAMPANAS>> {

        }
        public class Manejador : IRequestHandler<ListaTiposCampanas, List<TIPOSCAMPANAS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }
            public async Task<List<TIPOSCAMPANAS>> Handle (ListaTiposCampanas request, CancellationToken cancellationToken) {
                var tiposcampanas = await _context.TIPOSCAMPANAS.ToListAsync ();
                return tiposcampanas;
            }
        }
    }
}