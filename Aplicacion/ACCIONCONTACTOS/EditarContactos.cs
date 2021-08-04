using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCONTACTOS {
    public class EditarContactos {
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
            public DateTime? FECGRA { get; set; }
            public Guid CLIENTE_Id { get; set; }
            public Guid POSIBLECLIENTE_Id { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var contacto = await _context.CONTACTOS.FindAsync (request.CONTACTO_Id);
                if (contacto == null) {
                    throw new Exception ("El contacto no existe prro");
                }
                var _clienteId = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var _posibleClienteId = await _context.POSIBLESCLIENTES.FindAsync (request.POSIBLECLIENTE_Id);
                contacto.NOMBRE = request.NOMBRE ?? contacto.NOMBRE;
                contacto.APELLIDO = request.APELLIDO ?? contacto.APELLIDO;
                contacto.DIRECCION = request.DIRECCION ?? contacto.DIRECCION;
                contacto.TELEFONO = request.TELEFONO ?? contacto.TELEFONO;
                contacto.EMAIL = request.EMAIL ?? contacto.EMAIL;
                contacto.OBSERVACIONES = request.OBSERVACIONES ?? contacto.OBSERVACIONES;
                contacto.FECHULTMOD = DateTime.Now;
                contacto.CLIENTE = _clienteId ?? contacto.CLIENTE;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}