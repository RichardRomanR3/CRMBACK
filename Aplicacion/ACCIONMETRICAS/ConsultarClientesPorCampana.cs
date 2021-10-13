using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONMETRICAS
{
    public class ConsultarClientesPorCampana
    {
        public class Ejecuta : IRequest<List<CLIENTES>>
        {
            public Guid CAMPANA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta, List<CLIENTES>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context)
            {
                _context = context;
            }
            public async Task<List<CLIENTES>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var campana = await _context.CAMPANAS.Where(x => x.CAMPANA_Id == request.CAMPANA_Id).FirstOrDefaultAsync();
                var clientes = await _context.CLIENTES.Where(x => x.CAMPANAS == campana).ToListAsync();
                return clientes;
            }
        }
    }
}