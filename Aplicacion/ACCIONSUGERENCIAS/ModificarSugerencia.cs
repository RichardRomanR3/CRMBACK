using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONSUGERENCIAS
{
    public class ModificarSugerencia
    {
        public class Ejecuta : IRequest{
            public Guid Id {get;set;}
            public string estado {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var sugerencia = await _context.SUGERENCIAS.FindAsync(request.Id);
               sugerencia.estado=request.estado ?? sugerencia.estado;
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}