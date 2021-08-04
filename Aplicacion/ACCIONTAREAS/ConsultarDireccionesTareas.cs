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
    public class ConsultarDireccionesTareas {
        public class ListarDireccionesTareas : IRequest<List<DIRECCIONESTAREASDto>> {
            public Guid TAREA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<ListarDireccionesTareas, List<DIRECCIONESTAREASDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<DIRECCIONESTAREASDto>> Handle (ListarDireccionesTareas request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS.FindAsync (request.TAREA_Id);
                var direcciones = await _context.DIRECCIONESTAREAS
                    .Where (d => d.TAREA == tarea)
                    .Include (b => b.BARRIO)
                    .Include (c => c.CIUDAD)
                    .Include (x => x.CLIENTE)
                    .Include (x => x.TAREA).ToListAsync ();
                var direccionesDto = _mapper.Map<List<DIRECCIONESTAREAS>, List<DIRECCIONESTAREASDto>> (direcciones);
                return direccionesDto;
            }
        }
    }
}