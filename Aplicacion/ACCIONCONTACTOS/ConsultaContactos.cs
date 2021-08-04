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

namespace Aplicacion.ACCIONCONTACTOS {
    public class ConsultaContactos {

        public class ListaContactos : IRequest<List<CONTACTOSDto>> {
            public string USUARIOId { get; set; }

        }
        public class Manejador : IRequestHandler<ListaContactos, List<CONTACTOSDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CONTACTOSDto>> Handle (ListaContactos request, CancellationToken cancellationToken) {
                var contactos = await _context.CONTACTOS
                    .Where (x => x.UsuarioId == request.USUARIOId)
                    .OrderBy (x => x.FECGRA)
                    .Include (c => c.CLIENTE)
                    .ToListAsync ();
                var contactosDto = _mapper.Map<List<CONTACTOS>, List<CONTACTOSDto>> (contactos);
                return contactosDto;
            }
        }

    }
}