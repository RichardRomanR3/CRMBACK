using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class PantallasDelRol
    {
        
        public class Ejecuta : IRequest<RolDto> {

            public string codrol {set;get;}
            public string nombrerol{set;get;}
        }

        public class Manejador : IRequestHandler<Ejecuta, RolDto>
        {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador(CRMContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RolDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rolex = new Dominio.Roles{};
                if(request.codrol!=null){
                rolex = await _context.Roles
                .Include(x => x.PantallasLista)
                .ThenInclude(y => y.PANTALLA)
                .FirstOrDefaultAsync(a => a.Id == request.codrol);
                }else{
                rolex = await _context.Roles
                .Include(x => x.PantallasLista)
                .ThenInclude(y => y.PANTALLA)
                .FirstOrDefaultAsync(a => a.Name == request.nombrerol);
                }

                if(rolex==null){
                    throw new Exception("No se encontraron datos");
                }

                var rolexdto = _mapper.Map<Roles, RolDto>(rolex);

                return rolexdto;
            }
        }
    }
}