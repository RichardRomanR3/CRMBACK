using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTIPOTAREAS {
    public class ConsultaTiposTareasPorId {
        public class TipoTareaUnica : IRequest<TIPOSTAREAS> {
            public Guid TIPOTAREA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<TipoTareaUnica, TIPOSTAREAS> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<TIPOSTAREAS> Handle (TipoTareaUnica request, CancellationToken cancellationToken) {
                var tipotarea = await _context.TIPOSTAREAS.FindAsync (request.TIPOTAREA_Id);
                return tipotarea;
            }
        }

    }
}