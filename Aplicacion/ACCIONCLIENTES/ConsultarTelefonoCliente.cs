using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class ConsultarTelefonoCliente {
        public class Ejecuta : IRequest<List<TELEFONOS>> {
            public Guid CLIENTE_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<TELEFONOS>> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<List<TELEFONOS>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var telefono = await _context.TELEFONOS.Where (t => t.CLIENTE == cliente).ToListAsync ();
                return telefono;
            }
        }
    }
}