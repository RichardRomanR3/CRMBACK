using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONREPORTES
{
    public class ConsultarGraficoDeTareas
    {
        public class Ejecuta : IRequest<List<GRAFICO_TAREAS>>{
            
        }
        public class Manejador : IRequestHandler<Ejecuta, List<GRAFICO_TAREAS>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
_context=context;
            }
            public async Task<List<GRAFICO_TAREAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var grafico = await _context.GRAFICO_TAREAS.ToListAsync();
                return grafico;
            }
        }
    }
}