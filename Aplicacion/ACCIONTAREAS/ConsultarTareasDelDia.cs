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
    public class ConsultarTareasDelDia {
        public class Consultar : IRequest<List<TAREASGENERALESDto>> {
            public string USUARIOASIGNADO { get; set; }
        }
        public class Manejador : IRequestHandler<Consultar, List<TAREASGENERALESDto>> {

            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<TAREASGENERALESDto>> Handle (Consultar request, CancellationToken cancellationToken) {
                var list = await _context.TAREAS.Where (l => l.FECHAVTO.Date == DateTime.Now.Date && l.COMPLETADO == null && l.UsuarioId == request.USUARIOASIGNADO).OrderBy (l => l.FECHAVTO)
                    .Include (x => x.CLIENTES)
                    .Include (x => x.TIPOSTAREAS)
                    .Include (x=>x.POSIBLECLIENTE)
                    .ToListAsync ();
                var tareaDto = _mapper.Map<List<TAREAS>, List<TAREASGENERALESDto>> (list);
                return tareaDto;
            }
        }
    }
}