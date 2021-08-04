using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONPOSIBLESCLIENTES {
    public class NuevoPosibleCliente {
        public class Ejecuta : IRequest {
            public Guid POSIBLECLIENTE_Id { get; set; }
            public string NOMBRE { get; set; }
            public string APELLIDO { get; set; }
            public string RUC { get; set; }
            public string CI { get; set; }
            public string TELEFONO { get; set; }
            public string DIRECCION { get; set; }
            public string EMAIL { get; set; }
            public string USUARIO { get; set; }
            public string OBSERVACIONES { get; set; }
            public string PROFESIONORUBRO { get; set; }
            public string HOBBY { get; set; }
            public DateTime FECGRA { get; set; }
            public string UsuarioId {get;set;}

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                Guid _posibleclienteId = Guid.NewGuid ();
                var posiblecliente = new POSIBLESCLIENTES {
                    POSIBLECLIENTE_Id = _posibleclienteId,
                    NOMBRE = request.NOMBRE,
                    APELLIDO = request.APELLIDO,
                    RUC = request.RUC,
                    CI = request.CI,
                    TELEFONO = request.TELEFONO,
                    DIRECCION = request.DIRECCION,
                    EMAIL = request.EMAIL,
                    USUARIOPC = request.USUARIO,
                    OBSERVACIONES = request.OBSERVACIONES,
                    PROFESIONORUBRO = request.PROFESIONORUBRO,
                    HOBBY = request.HOBBY,
                    FECGRA = DateTime.Now,
                    UsuarioId=request.UsuarioId
                };
                _context.POSIBLESCLIENTES.Add (posiblecliente);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardo lpm");
            }
        }
    }
}