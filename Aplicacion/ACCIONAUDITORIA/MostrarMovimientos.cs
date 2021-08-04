using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONAUDITORIA
{
    public class MostrarMovimientos
    {
        public class Ejecuta :IRequest<List<AUDITORIA>>{
            
        }
        public class Manejador : IRequestHandler<Ejecuta, List<AUDITORIA>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
                _context=context;
            }   
            public async Task<List<AUDITORIA>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var lista = await _context.AUDITORIA.OrderByDescending(x=>x.fechadeaccion).ToListAsync();
                return lista;
            }
        }
    }
}