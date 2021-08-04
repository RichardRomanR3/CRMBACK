using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONSUGERENCIAS
{
    public class ConsultarSugerenciasPorId
    {
        public class Ejecuta:IRequest<List<SUGERENCIAS>>{
            public Guid cliente_id{get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, List<SUGERENCIAS>>
        {
        private readonly CRMContext _context;
        public Manejador(CRMContext context){
            _context=context;
        }
            public async Task<List<SUGERENCIAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var lista = await _context.SUGERENCIAS.Where(x=>x.ClienteId == request.cliente_id).ToListAsync();
                return lista;
            }
        }
    }
}