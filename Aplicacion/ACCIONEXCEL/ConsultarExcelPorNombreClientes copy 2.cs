using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONEXCEL
{
    public class ConsultarExcelPorNombreClientes
    {
        public class Ejecuta : IRequest<List<CLIENTES>>{
            public string nombreArchivo {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, List<CLIENTES>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
                    _context = context;
            }
            public async Task<List<CLIENTES>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var lista = await _context.CLIENTES.Where(x=>x.NombreArchivo == request.nombreArchivo).ToListAsync();
                return lista;
            }
        }
    }
}