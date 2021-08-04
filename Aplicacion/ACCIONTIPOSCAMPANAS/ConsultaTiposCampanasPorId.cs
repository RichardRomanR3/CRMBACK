using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTIPOSCAMPANAS {
    public class ConsultaTiposCampanasPorId {
        public class TipoCampanaUnica : IRequest<TIPOSCAMPANAS> {
            public Guid TIPOCAMPANA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<TipoCampanaUnica, TIPOSCAMPANAS> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<TIPOSCAMPANAS> Handle (TipoCampanaUnica request, CancellationToken cancellationToken) {
                var tipocampana = await _context.TIPOSCAMPANAS.FindAsync (request.TIPOCAMPANA_Id);
                return tipocampana;
            }
        }
    }
}