using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONSUGERENCIAS
{
    public class ListarSugerencias
    {
        public class Ejecuta : IRequest<List<SUGERENCIASDto>>{
            
        }
        public class Manejador : IRequestHandler<Ejecuta, List<SUGERENCIASDto>>
        {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador(CRMContext context,IMapper mapper){
                _context=context;
                _mapper=mapper;
            }
            public async Task<List<SUGERENCIASDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var lista = await _context.SUGERENCIAS
               .Include(x=>x.Cliente)
               .OrderBy(x=>x.FECGRA).ToListAsync();
               var sugerenciasDto = _mapper.Map<List<SUGERENCIAS>, List<SUGERENCIASDto>> (lista);
                return sugerenciasDto;
            }
        }
    }
}