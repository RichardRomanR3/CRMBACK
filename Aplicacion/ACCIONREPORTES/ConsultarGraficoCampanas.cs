using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONREPORTES
{
    public class ConsultarGraficoCampanas
    {
        public class Ejecuta : IRequest<List<GRAFICO_CAMPANAS>>
        {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<GRAFICO_CAMPANAS>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context)
            {
                _context = context;
            }
            public async Task<List<GRAFICO_CAMPANAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var grafico = await _context.GRAFICO_CAMPANAS.ToListAsync();
                return grafico;
            }
        }
    }
}