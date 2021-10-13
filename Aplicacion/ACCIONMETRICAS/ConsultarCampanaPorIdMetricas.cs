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
    public class ConsultarCampanaPorIdMetricas
    {
        public class Ejecuta : IRequest<CAC>
        {
            public Guid CAMPANA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta,CAC>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context)
            {
                _context = context;
            }
            public async Task<CAC> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var campana = await _context.CAMPANAS.Where(x => x.CAMPANA_Id == request.CAMPANA_Id).FirstOrDefaultAsync();
                var clientes = await _context.CLIENTES.Where(x => x.CAMPANAS == campana).CountAsync();

                var result = new CAC
                {
                    CAMPANA_Id = campana.CAMPANA_Id,
                    DESCRICAMPANA = campana.DESCRICAMPANA,
                    ESTADOCAMPANA = campana.ESTADOCAMPANA,
                    PRESUPUESTO = campana.PRESUPUESTO,
                    EMPRESACONTRATADA = campana.EMPRESACONTRATADA,
                    FECGRA = campana.FECGRA,
                    ClientesAlcanzados = clientes
                };
                return result;
            }
        }
    }
}