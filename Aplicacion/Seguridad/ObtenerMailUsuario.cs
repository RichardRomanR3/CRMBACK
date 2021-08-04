using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class ObtenerMailUsuario {
        public class Ejecuta : IRequest<Mail> {
            public string Email { get; set; }
            public string NOMBRECOMPLETO { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, Mail> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Mail> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var mail = await _context.Users.Where (x => x.NOMBRECOMPLETO == request.NOMBRECOMPLETO).FirstOrDefaultAsync ();
                var email = new Mail {
                    Email = mail.Email
                };
                return email;
            }
        }
    }
}