using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class NuevaTarea {
        public class Ejecuta : IRequest {

            public int CODTAREA { get; set; }
            public string NUMTAREA { get; set; }
            public string ASIGNADOPOR { get; set; }
            public string USUARIOASIGNADO { get; set; }
            public DateTime FECHACREACION { get; set; }
            public DateTime FECHAVTO { get; set; }
            public DateTime? ALARMA { get; set; }
            public DateTime? SINEMPEZAR { get; set; }
            public DateTime? COMENZADO { get; set; }
            public DateTime? COMPLETADO { get; set; }
            public DateTime? CANCELADO { get; set; }
            public string MOTIVOCANCELACION { get; set; }
            public TELEFONOSTAREAS[] TELEFONOSTAREAS { get; set; }
            public DIRECCIONESTAREAS[] DIRECCIONESTAREAS { get; set; }
            public DateTime FECGRA { get; set; }
            public Guid? PRESUPUESTO_Id { get; set; }
            public Guid? TIPOTAREA_Id { get; set; }
            public Guid? CLIENTE_Id { get; set; }
            public DateTime? POSIBLECOBRO {get;set;}
            public string UserName {get;set;}
            public string AsignadorId{get;set;}
            public Guid? POSIBLECLIENTEId {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            private readonly UserManager<Usuarios> _userManager;
            public Manejador (CRMContext context,UserManager<Usuarios> userManager) {
                _context = context;
                _userManager=userManager;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var _tipotareaId = await _context.TIPOSTAREAS.FindAsync (request.TIPOTAREA_Id);
                var _clienteId = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);
                var usuario = await _userManager.FindByNameAsync(request.UserName);
                Guid _tareaId = Guid.NewGuid ();
                var tarea = new TAREAS {
                    TAREA_Id = _tareaId,
                    CODTAREA = request.CODTAREA,
                    NUMTAREA = request.NUMTAREA,
                    ASIGNADOPOR = request.ASIGNADOPOR,
                    USUARIOASIGNADO = request.USUARIOASIGNADO,
                    FECHACREACION = request.FECHACREACION,
                    FECHAVTO = request.FECHAVTO,
                    SINEMPEZAR = request.SINEMPEZAR,
                    COMENZADO = request.COMENZADO,
                    COMPLETADO = request.COMPLETADO,
                    CANCELADO = request.CANCELADO,
                    MOTIVOCANCELACION = request.MOTIVOCANCELACION,
                    FECGRA = DateTime.Now,
                    TIPOSTAREAS = _tipotareaId,
                    CLIENTES = _clienteId,
                    ALARMA = request.ALARMA ?? request.FECHAVTO,
                    UsuarioId=usuario.Id,
                    AsignadorId=request.AsignadorId,
                    POSIBLECOBRO=request.POSIBLECOBRO,
                    POSIBLECLIENTEId= request.POSIBLECLIENTEId,
                };
                _context.TAREAS.Add (tarea);
                if (request.TELEFONOSTAREAS != null) {
                    var tel = request.TELEFONOSTAREAS;
                    var tarid = await _context.TAREAS.FindAsync (_tareaId);
                    var contt = 0;
                    foreach (TELEFONOSTAREAS telefono in tel) {
                        Guid _telefonoId = Guid.NewGuid ();
                        telefono.TELEFONOTAREA_Id = _telefonoId;
                        telefono.CODTELEFONOTAREA = request.TELEFONOSTAREAS[contt].CODTELEFONOTAREA;
                        telefono.DESCRITELEFONOTAREA = request.TELEFONOSTAREAS[contt].DESCRITELEFONOTAREA;
                        telefono.CLIENTE = _clienteId;
                        _context.TELEFONOSTAREAS.Add (telefono);
                        telefono.TAREA = tarid;
                        contt++;
                    }
                }
                if (request.DIRECCIONESTAREAS != null) {
                    var dir = request.DIRECCIONESTAREAS;
                    var tarid = await _context.TAREAS.FindAsync (_tareaId);
                    var contd = 0;
                    foreach (DIRECCIONESTAREAS direcciones in dir) {
                        var _barrioId = await _context.BARRIOS.FindAsync (request.DIRECCIONESTAREAS[contd].BARRIO.BARRIO_Id);
                        var _ciudadId = await _context.CIUDADES.FindAsync (request.DIRECCIONESTAREAS[contd].CIUDAD.CIUDAD_Id);
                        Guid _direccionId = Guid.NewGuid ();
                        direcciones.DIRECCION_Id = _direccionId;
                        direcciones.CODDIRECCION = request.DIRECCIONESTAREAS[contd].CODDIRECCION;
                        direcciones.DESCRIDIRECCION = request.DIRECCIONESTAREAS[contd].DESCRIDIRECCION;
                        direcciones.BARRIO = _barrioId;
                        direcciones.CIUDAD = _ciudadId;
                        direcciones.CLIENTE = _clienteId;
                        direcciones.TAREA = tarid;
                        _context.DIRECCIONESTAREAS.Add (direcciones);
                        contd++;
                    }
                }
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardo lpm");
            }
        }
    }
}