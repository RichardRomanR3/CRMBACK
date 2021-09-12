using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS
{
    public class ListarComentariosDeTarea
    {
        public class Ejecuta : IRequest<List<COMENTARIOSDETAREAS>>{
            public Guid TAREA_Id{get;set;}
            public class Manejador : IRequestHandler<Ejecuta, List<COMENTARIOSDETAREAS>>
            {
                private readonly CRMContext _context;
                public Manejador(CRMContext context){
_context=context;
                }
                public async Task<List<COMENTARIOSDETAREAS>> Handle(Ejecuta request, CancellationToken cancellationToken)
                {
                   var lista = await _context.COMENTARIOSDETAREAS.Where(x=>x.TAREAId == request.TAREA_Id).OrderByDescending(x=>x.FECGRA).ToListAsync();
                   return lista;
                }
            }
        }
    }
}