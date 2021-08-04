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
    public class ConsultaTareasGeneralesAsigPor {
        public class ListaTareas : IRequest<List<TAREASGENERALESDto>> {
            public string ASIGNADOPOR { get; set; }
        }
        public class Manejador : IRequestHandler<ListaTareas, List<TAREASGENERALESDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;

            }

            public async Task<List<TAREASGENERALESDto>> Handle (ListaTareas request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS
                    .Where (x => x.AsignadorId == request.ASIGNADOPOR)
                    .Include (x => x.TIPOSTAREAS)
                    .Include (x => x.CLIENTES)
                    .Include(x=>x.Usuario)
                    .OrderBy (x => x.FECHAVTO)
                    .ToListAsync ();
                var tareaDto = _mapper.Map<List<TAREAS>, List<TAREASGENERALESDto>> (tarea);
                return tareaDto;
            }
        }
    }
}