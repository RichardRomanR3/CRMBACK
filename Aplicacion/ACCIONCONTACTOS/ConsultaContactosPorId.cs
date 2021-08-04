using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCONTACTOS {
    public class ConsultaContactosPorId {
        public class ContactoUnico : IRequest<CONTACTOS> {
            public Guid CONTACTO_Id { get; set; }

        }
        public class Manejador : IRequestHandler<ContactoUnico, CONTACTOS> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<CONTACTOS> Handle (ContactoUnico request, CancellationToken cancellationToken) {
                var contacto = await _context.CONTACTOS.FindAsync (request.CONTACTO_Id);
                return contacto;
            }
        }
    }
}