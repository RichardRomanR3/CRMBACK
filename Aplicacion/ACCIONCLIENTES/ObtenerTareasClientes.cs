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

namespace Aplicacion.ACCIONCLIENTES {
    public class ObtenerTareasClientes {
        public class Ejecuta : IRequest<List<TAREASDto>> {
            public Guid ClienteId { set; get; }

        }

        public class Manejador : IRequestHandler<Ejecuta, List<TAREASDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<TAREASDto>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.ClienteId);

                var lista = await _context.TAREAS.Where (x => x.CLIENTES == cliente).ToListAsync ();

                var TAREASDto = _mapper.Map<List<TAREAS>, List<TAREASDto>> (lista);

                return TAREASDto;
            }
        }
    }
}