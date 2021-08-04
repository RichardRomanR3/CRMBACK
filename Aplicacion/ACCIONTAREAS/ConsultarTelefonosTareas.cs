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
    public class ConsultarTelefonosTareas {
        public class ListarTelefonosTareas : IRequest<List<TELEFONOSTAREASDto>> {
            public Guid TAREA_Id;
        }
        public class Manejador : IRequestHandler<ListarTelefonosTareas, List<TELEFONOSTAREASDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;

            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<TELEFONOSTAREASDto>> Handle (ListarTelefonosTareas request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS.FindAsync (request.TAREA_Id);
                var telefonos = await _context.TELEFONOSTAREAS
                    .Where (d => d.TAREA == tarea)
                    .Include (x => x.TAREA).ToListAsync ();
                var telefonosDto = _mapper.Map<List<TELEFONOSTAREAS>, List<TELEFONOSTAREASDto>> (telefonos);
                return telefonosDto;
            }
        }
    }
}