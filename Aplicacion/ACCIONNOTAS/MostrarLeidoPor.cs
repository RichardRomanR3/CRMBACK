using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONNOTAS {
    public class MostrarLeidoPor {
        public class Ejecuta : IRequest<List<V_LEIDO_POR>> {
            public Guid NOTA_ID { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<V_LEIDO_POR>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<List<V_LEIDO_POR>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var lista = await _context.V_LEIDO_POR.Where (x => x.NOTA_ID == request.NOTA_ID).ToListAsync ();
                return lista;
            }
        }
    }
}