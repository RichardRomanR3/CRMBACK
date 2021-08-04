using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONEXCEL
{
    public class EliminarPorArchivosClientes
    {
        public class Ejecuta : IRequest{
            public string nombreArchivo {get;set;}
            public DateTime fecgra {get;set;}

        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
             _context=context;
            }
            public async  Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                 _context.CLIENTES.RemoveRange(_context.CLIENTES.Where(x=>x.NombreArchivo == request.nombreArchivo && x.FECGRA.Date == request.fecgra.Date));
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0) {
                    return Unit.Value;
                }
                throw new System.Exception ("NO SE REALIZO LA OPERACION LPM");
            }
        }
    }
}