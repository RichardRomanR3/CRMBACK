using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONCLIENTES {
    public class NuevoCliente {
        public class Ejecuta : IRequest {
            public Guid CLIENTE_Id { get; set; }
            public int CODCLIENTE { get; set; }
            public string NUMCLIENTE { get; set; }
            public string NOMBRE { get; set; }
            public string APELLIDO { get; set; }
            public string CI { get; set; }
            public string RUC { get; set; }
            public string PROFESIONORUBRO { get; set; }
            public string HOBBY { get; set; }
            public DateTime FECGRA { get; set; }
            public Guid? CAMPANA_Id { get; set; }
            public TELEFONOS[] TELEFONOS { get; set; }
            public int CODTELEFONO { get; set; }
            public string DESCRITELEFONO { get; set; }
            public DIRECCIONES[] DIRECCIONES { get; set; }
            public REDES_CLIENTES[] REDES { get; set; }

            public int CODDIRECCION { get; set; }
            public string DESCRIDIRECCION { get; set; }
            public Guid BARRIO_Id { get; set; }
            public Guid CIUDAD_Id { get; set; }
            public string OBSERVACIONES {get;set;}
            public DateTime? ENTROCOMOPC { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var _campanaId = await _context.CAMPANAS.FindAsync (request.CAMPANA_Id);
                Guid _clienteId = Guid.NewGuid ();
                var cliente = new CLIENTES {
                    CLIENTE_Id = _clienteId,
                    CODCLIENTE = request.CODCLIENTE,
                    NUMCLIENTE = request.NUMCLIENTE,
                    NOMBRE = request.NOMBRE,
                    APELLIDO = request.APELLIDO,
                    CI = request.CI,
                    RUC = request.RUC,
                    FECGRA = DateTime.Now,
                    CAMPANAS = _campanaId,
                    PROFESIONORUBRO = request.PROFESIONORUBRO,
                    HOBBY = request.HOBBY,
                    OBSERVACIONES=request.OBSERVACIONES,
                    ENTROCOMOPC=request.ENTROCOMOPC
                };
                _context.CLIENTES.Add (cliente);
                if (request.TELEFONOS != null) {
                    var tel = request.TELEFONOS;
                    var _clientesId = await _context.CLIENTES.FindAsync (_clienteId);
                    var contt = 0;
                    foreach (TELEFONOS telefono in tel) {
                        Guid _telefonoId = Guid.NewGuid ();
                        telefono.TELEFONO_Id = _telefonoId;
                        telefono.CODTELEFONO = request.TELEFONOS[contt].CODTELEFONO;
                        telefono.DESCRITELEFONO = request.TELEFONOS[contt].DESCRITELEFONO;
                        telefono.CLIENTE = _clientesId;
                        _context.TELEFONOS.Add (telefono);
                        contt++;
                    }
                }
                if (request.DIRECCIONES != null) {
                    var dir = request.DIRECCIONES;
                    var _clientesId = await _context.CLIENTES.FindAsync (_clienteId);
                    var contd = 0;
                    foreach (DIRECCIONES direcciones in dir) {
                        var _barrioId = await _context.BARRIOS.FindAsync (request.DIRECCIONES[contd].BARRIO.BARRIO_Id);
                        var _ciudadId = await _context.CIUDADES.FindAsync (request.DIRECCIONES[contd].CIUDAD.CIUDAD_Id);
                        Guid _direccionId = Guid.NewGuid ();
                        direcciones.DIRECCION_Id = _direccionId;
                        direcciones.CODDIRECCION = request.DIRECCIONES[contd].CODDIRECCION;
                        direcciones.DESCRIDIRECCION = request.DIRECCIONES[contd].DESCRIDIRECCION;
                        direcciones.BARRIO = _barrioId;
                        direcciones.CIUDAD = _ciudadId;
                        direcciones.CLIENTE = _clientesId;
                        _context.DIRECCIONES.Add (direcciones);
                        contd++;
                    }
                }
                if (request.REDES != null) {
                    var red = request.REDES;
                    var _clientesId = await _context.CLIENTES.FindAsync (_clienteId);
                    var contr = 0;
                    foreach (REDES_CLIENTES redes in red) {
                        Guid _red_Id = Guid.NewGuid ();
                        redes.RED_Id = _red_Id;
                        redes.Nick = request.REDES[contr].Nick;
                        redes.RedSocial = request.REDES[contr].RedSocial;
                        redes.CLIENTE = _clientesId;
                        _context.REDES_CLIENTES.Add (redes);
                        contr++;
                    }
                }

                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");
            }
        }
    }
}