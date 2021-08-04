using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class ObtenerNumeroDeTelefonoUsuario {
        public class Ejecuta : IRequest<NUMTELEFONO> {
            public string NUMEROTELEFONO { get; set; }
            public string NOMBRECOMPLETO { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, NUMTELEFONO> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<NUMTELEFONO> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var numero = await _context.Users.Where (x => x.NOMBRECOMPLETO == request.NOMBRECOMPLETO).FirstOrDefaultAsync ();
                var numerotel = new NUMTELEFONO {
                    NUMEROTELEFONO = numero.NUMEROTELEFONO
                };
                return numerotel;
            }
        }
    }
}