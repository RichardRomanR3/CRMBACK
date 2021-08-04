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
    public class ConsultaCampanas {
        public class ListaCampanas : IRequest<List<CAMPANASDto>> {

        }
        public class Manejador : IRequestHandler<ListaCampanas, List<CAMPANASDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;

            }
            public async Task<List<CAMPANASDto>> Handle (ListaCampanas request, CancellationToken cancellationToken) {
                var campanas = await _context.CAMPANAS
                    .Where(x=>x.ESTADOCAMPANA=="Activo")
                    .Include (x => x.ClientesLista)
                    .Include (x => x.TIPOSCAMPANAS).ToListAsync ();
                var campanasDto = _mapper.Map<List<CAMPANAS>, List<CAMPANASDto>> (campanas);
                return campanasDto;
            }
        }

    }
}