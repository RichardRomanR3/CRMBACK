using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ACCIONNOTAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS {
    public class ContarTareasCerradas {
        public class Contar : IRequest<CONTEO> {
            public string UserName {get;set;}
            public string USUARIOASIGNADO { get; set; }
            public int cuenta { get; set; }
        }
        public class Manejador : IRequestHandler<Contar, CONTEO> {
            private readonly CRMContext _context;
            private readonly IHubContext<ChatHub> _chatHub;
            public Manejador (CRMContext context,IHubContext<ChatHub> chatHub) {
                _context = context;
                _chatHub=chatHub;
            }

            public async Task<CONTEO> Handle (Contar request, CancellationToken cancellationToken) {
                var cont = await _context.TAREAS.Where (t => t.COMPLETADO.Value.Date == DateTime.Now.Date && t.UsuarioId == request.USUARIOASIGNADO).CountAsync ();
                var cuenta = new CONTEO {
                    USUARIOASIGNADO = request.USUARIOASIGNADO,
                    cuenta = cont
                };
                  await _chatHub.Clients.Group(request.UserName).SendAsync("CuentaTareasCerradas", cuenta);
                  return cuenta;
            }
        }
    }
}