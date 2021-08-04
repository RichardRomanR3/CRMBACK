using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONCIUDADES {
    public class ConsultarCiudades {
        public class ListarCiudades : IRequest<List<CIUDADES>> {

        }
        public class Manejador : IRequestHandler<ListarCiudades, List<CIUDADES>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<List<CIUDADES>> Handle (ListarCiudades request, CancellationToken cancellationToken) {
                var ciudades = await _context.CIUDADES.ToListAsync ();
                return ciudades;
            }
        }
    }
}