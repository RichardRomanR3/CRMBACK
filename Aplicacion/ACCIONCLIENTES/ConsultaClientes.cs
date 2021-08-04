using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class ConsultaClientes {
        public class ListaClientes : IRequest<List<CLIENTESDto>> {

        }
        public class Manejador : IRequestHandler<ListaClientes, List<CLIENTESDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;

            }
            public async Task<List<CLIENTESDto>> Handle (ListaClientes request, CancellationToken cancellationToken) {
                var clientes = await _context.CLIENTES.Include(x => x.CAMPANAS).ToListAsync ();
                var clientesDto = _mapper.Map<List<CLIENTES>, List<CLIENTESDto>> (clientes);
                return clientesDto;
            }
        }

    }
}