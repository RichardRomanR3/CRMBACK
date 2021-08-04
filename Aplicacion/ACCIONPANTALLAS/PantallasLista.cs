using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class PantallasLista
    {
        
        public class Ejecuta : IRequest<List<PANTALLAS>> {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<PANTALLAS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<List<PANTALLAS>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var listapantallas = await _context.PANTALLAS.ToListAsync ();
                return listapantallas;
            }
        }
    }
}