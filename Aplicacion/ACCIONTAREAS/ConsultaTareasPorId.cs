using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class ConsultaTareasPorId {
        public class TareaUnica : IRequest<List<TAREASGENERALESDto>> {
            public Guid TAREA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<TareaUnica, List<TAREASGENERALESDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TAREASGENERALESDto>> Handle (TareaUnica request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS
                    .Include (x => x.TIPOSTAREAS)
                    .Include (x => x.CLIENTES)
                    .Include (x=>x.POSIBLECLIENTE)
                    .Where (t => t.TAREA_Id == request.TAREA_Id)
                    .ToListAsync ();
                var tareaDto = _mapper.Map<List<TAREAS>, List<TAREASGENERALESDto>> (tarea);
                return tareaDto;
            }
        }

    }
}