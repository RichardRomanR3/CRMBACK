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

namespace Aplicacion.ACCIONCAMPANAS {
    public class ObtenerClientesPorCampana {
        public class Ejecuta : IRequest<List<CLIENTESDto>> {
            public Guid CAMPANA_Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<CLIENTESDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CLIENTESDto>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var campana = await _context.CAMPANAS.FindAsync (request.CAMPANA_Id);
                var lista = await _context.CLIENTES.Where (x => x.CAMPANAS == campana).ToListAsync ();
                var clientesDto = _mapper.Map<List<CLIENTES>, List<CLIENTESDto>> (lista);
                return clientesDto;
            }
        }
    }
}