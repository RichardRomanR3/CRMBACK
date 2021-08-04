using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class AsignarPantallasARoles
    {
        public class Ejecuta : IRequest{
            public string ROL_Id{get;set;}
            public Guid PANTALLA_Id {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            
            private readonly CRMContext _context;
            public Manejador(CRMContext context){
                _context=context;
               
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                 /*EL FRONT SIEMPRE ENVIA PANTALLAS PARA HABILITAR Y DESHABILITAR, ES DECIR, VIENEN 
                COMBINACIONES ROLID Y PANTALLAID QUE PUEDE QUE YA FIGUREN EN LA TABLA ENTONCES DEBEMOS
                VERIFICAR SI YA FIGURA O NO LA COMBINACION Y SOLO INSERTAR EN EL CASO DE QUE NO FIGURE
                */ 
                var rol_pantalla_existe = _context.ROLES_PANTALLAS.Where(
                    x => x.RoleId == request.ROL_Id && x.PANTALLAId == request.PANTALLA_Id).FirstOrDefault();
                
                var valor = 0;

                if(rol_pantalla_existe==null){
                

                    var rol_pantalla = new ROLES_PANTALLAS{
                      RoleId=request.ROL_Id,
                      PANTALLAId = request.PANTALLA_Id
                    };

                     _context.ROLES_PANTALLAS.Add(rol_pantalla);
                
                    valor = await _context.SaveChangesAsync();

                }

                return Unit.Value;
            }
        }
    }
}