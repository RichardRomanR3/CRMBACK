using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class TraerUltimaTarea {
        public class Ejecuta : IRequest<ULTIMO> {
            public int ULTIMOCOD { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, ULTIMO> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<ULTIMO> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var ultimo = await _context.TAREAS.ToListAsync ();
                var ultimatum = ultimo.ToList ().Last ();
                /* foreach(TAREAS tAREAS in ultimo)
             {
                  
             } */
                var ultimatum2 = new ULTIMO {
                    ULTIMOCOD = ultimatum.CODTAREA
                };
                return ultimatum2;
            }
        }
    }
}