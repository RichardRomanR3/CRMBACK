using System;
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
    public class ConsultarArchivosPosiblesClientes
    {
        public class Ejecuta : IRequest<List<V_ARCHIVOS_POSIBLESCLIENTES>>{
            public DateTime fecha {get;set;}
         
        }
        public class Manejador : IRequestHandler<Ejecuta, List<V_ARCHIVOS_POSIBLESCLIENTES>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
            _context=context;
            }
            public async Task<List<V_ARCHIVOS_POSIBLESCLIENTES>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
            var lista = await _context.V_ARCHIVOS_POSIBLESCLIENTES.Where(x=>x.fechaarchivo.Date == request.fecha.Date).ToListAsync();
           
            return lista;
            }
        }
    }
}