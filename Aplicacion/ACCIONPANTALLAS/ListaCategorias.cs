using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class ListaCategorias
    {
        
        public class Ejecuta : IRequest<List<CategoriaDto>> {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<CategoriaDto>> {
            private readonly CRMContext _context;
            private IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoriaDto>> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var listacategorias = await _context.CATEGORIA
                 .Include (c => c.SubcategoriasLista)
                 .ThenInclude(d => d.PantallasLista)
                 .ToListAsync();
                var listacategoriasdto = _mapper.Map<List<Categoria>, List<CategoriaDto>> (listacategorias);
                return listacategoriasdto;
            }
        }
    }
}