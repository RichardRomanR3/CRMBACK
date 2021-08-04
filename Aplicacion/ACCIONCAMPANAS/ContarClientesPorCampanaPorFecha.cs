using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONCAMPANAS {
    public class ContarClientesPorCampanaPorFecha {
        public class Ejecuta : IRequest<CONTEO> {
            public Guid CAMPANA_Id { get; set; }
            public DateTime DESDE { get; set; }
            public DateTime HASTA { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, CONTEO> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<CONTEO> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var campana = await _context.CAMPANAS.FindAsync (request.CAMPANA_Id);
                var cont = await _context.CLIENTES.Where (x => x.CAMPANAS == campana && x.FECGRA >= request.DESDE && x.FECGRA <= request.HASTA).CountAsync ();
                var cuenta = new CONTEO {
                    USUARIOASIGNADO = "",
                    cuenta = cont
                };
                return cuenta;
            }
        }
    }
}