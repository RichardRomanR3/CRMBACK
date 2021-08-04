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
    public class ConsultarTelefonos {
        public class ListarTelefonos : IRequest<List<TELEFONOSDto>> {
            public Guid CLIENTE_Id { get; set; }
        }
        public class Manejador : IRequestHandler<ListarTelefonos, List<TELEFONOSDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TELEFONOSDto>> Handle (ListarTelefonos request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var telefonos = await _context.TELEFONOS
                    .Where (d => d.CLIENTE == cliente)
                    .Include (x => x.CLIENTE).ToListAsync ();
                var telefonosDto = _mapper.Map<List<TELEFONOS>, List<TELEFONOSDto>> (telefonos);
                return telefonosDto;
            }
        }
    }
}