using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class EliminarPermisos {
        public class Ejecuta : IRequest {
            public string ROL_Id { get; set; }
            public Guid PANTALLA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var resultado=0;
                var existe = await _context.ROLES_PANTALLAS.Where (x => x.RoleId == request.ROL_Id && x.PANTALLAId == request.PANTALLA_Id).AnyAsync ();
                if (existe) {
                    var rol_pantalla = await _context.ROLES_PANTALLAS.Where (x => x.RoleId == request.ROL_Id && x.PANTALLAId == request.PANTALLA_Id).FirstAsync ();
                    _context.Remove (rol_pantalla);
                   resultado = await _context.SaveChangesAsync();
                }else{
                    Console.WriteLine("NO EXISTE LOS DATOS EN ROL_PANTALLA");
                }   
                    if (resultado > 0) {
                    return Unit.Value;
                }
                return Unit.Value;
            }
        }
    }
}