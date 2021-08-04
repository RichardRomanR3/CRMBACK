using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCONTACTOS {
    public class NuevoContacto {
        public class Ejecuta : IRequest {
            public Guid CONTACTO_Id { get; set; }
            public int CODCONTACTO { get; set; }
            public string NUMCONTACTO { get; set; }
            public string NOMBRE { get; set; }
            public string APELLIDO { get; set; }
            public string CI { get; set; }
            public string RUC { get; set; }
            public string DIRECCION { get; set; }
            public string TELEFONO { get; set; }
            public string EMAIL { get; set; }
            public string OBSERVACIONES { get; set; }
            public string USUARIO { get; set; }
            public DateTime FECGRA { get; set; }
            public Guid? CLIENTE_Id { get; set; }
            public string UsuarioId {get;set;}

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                Guid _contactoId = Guid.NewGuid ();
                var _clienteId = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);

                var contacto = new CONTACTOS {
                    CONTACTO_Id = _contactoId,
                    NOMBRE = request.NOMBRE,
                    APELLIDO = request.APELLIDO,
                    DIRECCION = request.DIRECCION,
                    TELEFONO = request.TELEFONO,
                    EMAIL = request.EMAIL,
                    OBSERVACIONES = request.OBSERVACIONES,
                    FECGRA = DateTime.Now,
                    USUARIOP = request.USUARIO,
                    CLIENTE = _clienteId,
                    UsuarioId=request.UsuarioId
                };
                _context.CONTACTOS.Add (contacto);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardo lpm");
            }
        }
    }
}