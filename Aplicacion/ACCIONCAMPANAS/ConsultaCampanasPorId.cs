using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCAMPANAS {
    public class ConsultaCampanasPorId {
        public class CampanaUnica : IRequest<CAMPANAS> {
            public Guid CAMPANA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<CampanaUnica, CAMPANAS> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<CAMPANAS> Handle (CampanaUnica request, CancellationToken cancellationToken) {
                var campana = await _context.CAMPANAS.FindAsync (request.CAMPANA_Id);
                return campana;
            }
        }
    }
}