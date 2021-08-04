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
    public class ListarNotasDelDia {
        public class Ejecuta : IRequest<List<NOTAS>> {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<NOTAS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<List<NOTAS>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var lista = await _context.NOTAS.Where (x => x.FECGRA.Date == DateTime.Now.Date && x.DIFUSION == "SI").OrderByDescending (x => x.FECGRA).ToListAsync ();
                return lista;
            }
        }
    }
}