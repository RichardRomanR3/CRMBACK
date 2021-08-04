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
    public class ConsultarRedesCliente {
        public class Ejecuta : IRequest<List<REDES_CLIENTESDto>> {
            public Guid CLIENTE_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, List<REDES_CLIENTESDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<REDES_CLIENTESDto>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var redes = await _context.REDES_CLIENTES
                    .Where (d => d.CLIENTE == cliente)
                    .Include (x => x.CLIENTE).ToListAsync ();
                var redesDto = _mapper.Map<List<REDES_CLIENTES>, List<REDES_CLIENTESDto>> (redes);
                return redesDto;
            }
        }
    }
}