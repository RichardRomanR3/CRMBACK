using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTIPOTAREAS {
    public class ConsultaTiposTareas {
        public class ListaTiposTareas : IRequest<List<TIPOSTAREAS>> {

        }
        public class Manejador : IRequestHandler<ListaTiposTareas, List<TIPOSTAREAS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }
            public async Task<List<TIPOSTAREAS>> Handle (ListaTiposTareas request, CancellationToken cancellationToken) {
                var tipostareas = await _context.TIPOSTAREAS.ToListAsync ();
                return tipostareas;
            }
        }
    }
}