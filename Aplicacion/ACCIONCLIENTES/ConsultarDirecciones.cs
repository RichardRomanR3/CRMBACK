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
    public class ConsultarDirecciones {
        public class ListarDirecciones : IRequest<List<DIRECCIONESDto>> {
            public Guid CLIENTE_Id { get; set; }
        }
        public class Manejador : IRequestHandler<ListarDirecciones, List<DIRECCIONESDto>> {
            public readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<DIRECCIONESDto>> Handle (ListarDirecciones request, CancellationToken cancellationToken) {
                var cliente = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var direcciones = await _context.DIRECCIONES
                    .Where (d => d.CLIENTE == cliente)
                    .Include (b => b.BARRIO)
                    .Include (c => c.CIUDAD)
                    .Include (x => x.CLIENTE).ToListAsync ();
                var direccionesDto = _mapper.Map<List<DIRECCIONES>, List<DIRECCIONESDto>> (direcciones);
                return direccionesDto;
            }
        }
    }
}