using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONALERTAS
{
    public class AlertaPorUsuario
    {
        public class Ejecuta : IRequest<List<ALERTAS>>{
            public string UsuarioId {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, List<ALERTAS>>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
             _context=context;
            }
            public async Task<List<ALERTAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var alerta = await _context.ALERTAS.Where(x=>x.UsuarioId == request.UsuarioId).ToListAsync();
               return alerta;
            }
        }
    }
}