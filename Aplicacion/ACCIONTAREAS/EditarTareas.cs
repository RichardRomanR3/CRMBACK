using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class EditarTareas {
        public class Ejecuta : IRequest {
            public Guid TAREA_Id { get; set; }
            public int CODTAREA { get; set; }
            public string NUMTAREA { get; set; }
            public string USUARIOASIGNADO { get; set; }
            public DateTime? FECHACREACION { get; set; }
            public DateTime? FECHAVTO { get; set; }
            public DateTime? SINEMPEZAR { get; set; }
            public DateTime? COMENZADO { get; set; }
            public DateTime? COMPLETADO { get; set; }
            public DateTime? CANCELADO { get; set; }
            public string MOTIVOCANCELACION { get; set; }
            public string NOTIFICADO { get; set; }
            public DateTime? ALARMA { get; set; }
            public DateTime? FECGRA { get; set; }
            public Guid PRESUPUESTO_Id { get; set; }
            public Guid TIPOTAREA_Id { get; set; }
            public Guid CLIENTE_Id { get; set; }
            public string COBROASIGNADO { get; set; }
            public DateTime? POSIBLECOBRO { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var tarea = await _context.TAREAS.FindAsync (request.TAREA_Id);
                if (tarea == null) {
                    throw new Exception ("LA TAREA NO existe prro");
                }
                var _tipotareaId = await _context.TIPOSTAREAS.FindAsync (request.TIPOTAREA_Id);
                var _clienteId = await _context.CLIENTES.FindAsync (request.CLIENTE_Id);

                tarea.NUMTAREA = request.NUMTAREA ?? tarea.NUMTAREA;
                tarea.USUARIOASIGNADO = request.USUARIOASIGNADO ?? tarea.USUARIOASIGNADO;
                tarea.FECHACREACION = request.FECHACREACION ?? tarea.FECHACREACION;
                tarea.FECHAVTO = request.FECHAVTO ?? tarea.FECHAVTO;
                tarea.SINEMPEZAR = request.SINEMPEZAR ?? tarea.SINEMPEZAR;
                tarea.COMENZADO = request.COMENZADO ?? tarea.COMENZADO;
                tarea.COMPLETADO = request.COMPLETADO ?? tarea.COMPLETADO;
                tarea.CANCELADO = request.CANCELADO ?? tarea.CANCELADO;
                tarea.MOTIVOCANCELACION = request.MOTIVOCANCELACION ?? tarea.MOTIVOCANCELACION;
                tarea.TIPOSTAREAS = _tipotareaId ?? tarea.TIPOSTAREAS;
                tarea.CLIENTES = _clienteId ?? tarea.CLIENTES;
                tarea.NOTIFICADO = request.NOTIFICADO ?? tarea.NOTIFICADO;
                tarea.ALARMA = request.ALARMA ?? tarea.ALARMA;
                tarea.POSIBLECOBRO = request.POSIBLECOBRO ?? tarea.POSIBLECOBRO;
                tarea.COBROASIGNADO = request.COBROASIGNADO ?? tarea.COBROASIGNADO;

                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }
    }
}