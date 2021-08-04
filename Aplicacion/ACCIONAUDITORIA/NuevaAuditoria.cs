using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONAUDITORIA
{
    public class NuevaAuditoria
    {
        public class Ejecuta : IRequest{
        public string usuario {get;set;}
        public string accion {get;set;}
        public string panel {get;set;}
        public string tabla {get;set;}
        public string filaafectada {get;set;}
        public string UsuarioId {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
_context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var auditoria_Id = Guid.NewGuid();
                var auditoria = new AUDITORIA {
                 Id=auditoria_Id,
                 usuarionombre=request.usuario,
                 accion=request.accion,
                 panel=request.panel,
                 tabla=request.tabla,
                 filaafectada=request.filaafectada,
                 fechadeaccion= DateTime.Now,
                 UsuarioId = request.UsuarioId
                };
                 await _context.AUDITORIA.AddAsync (auditoria);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardo lpm");
            }
        }
    }
}