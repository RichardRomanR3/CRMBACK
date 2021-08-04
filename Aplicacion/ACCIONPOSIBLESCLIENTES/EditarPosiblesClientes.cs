using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONPOSIBLESCLIENTES {
    public class EditarPosiblesClientes {
        public class Ejecuta : IRequest {
            public Guid POSIBLECLIENTE_Id { get; set; }
            public int CODPOSIBLECLIENTE { get; set; }
            public string NUMPOSIBLECLIENTE { get; set; }
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
            public DateTime? FECGRA { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var posiblecliente = await _context.POSIBLESCLIENTES.FindAsync (request.POSIBLECLIENTE_Id);
                if (posiblecliente == null) {
                    throw new Exception ("EL POSIBLE CLIENTE existe prro");
                }
                posiblecliente.NOMBRE = request.NOMBRE ?? posiblecliente.NOMBRE;
                posiblecliente.APELLIDO = request.APELLIDO ?? posiblecliente.APELLIDO;
                posiblecliente.RUC = request.RUC ?? posiblecliente.RUC;
                posiblecliente.CI = request.CI ?? posiblecliente.CI;
                posiblecliente.TELEFONO = request.TELEFONO ?? posiblecliente.TELEFONO;
                posiblecliente.DIRECCION = request.DIRECCION ?? posiblecliente.DIRECCION;
                posiblecliente.USUARIOPC = request.USUARIO ?? posiblecliente.USUARIOPC;
                posiblecliente.OBSERVACIONES = request.OBSERVACIONES ?? posiblecliente.OBSERVACIONES;
                posiblecliente.EMAIL = request.EMAIL ?? posiblecliente.EMAIL;
                posiblecliente.PROFESIONORUBRO = request.PROFESIONORUBRO ?? posiblecliente.PROFESIONORUBRO;
                posiblecliente.HOBBY = request.HOBBY ?? posiblecliente.HOBBY;
                posiblecliente.ULTIMOMOD = DateTime.Now;
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}