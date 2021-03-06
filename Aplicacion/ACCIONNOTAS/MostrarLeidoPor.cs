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
        public class Ejecuta : IRequest<List<DIFUSIONESLEIDAS>> {
            public Guid NOTA_ID { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<DIFUSIONESLEIDAS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<List<DIFUSIONESLEIDAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                 var nota = await _context.NOTAS.FindAsync(request.NOTA_ID);
                var lista = await _context.DIFUSIONESLEIDAS.Where (x => x.NOTA == nota).ToListAsync();
                return lista;
            }
        }
    }
}