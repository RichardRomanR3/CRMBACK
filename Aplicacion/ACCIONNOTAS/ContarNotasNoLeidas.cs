using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONNOTAS {
    public class ContarNotasNoLeidas {
        public class Contar : IRequest<CONTEO> {
            public string USUARIOASIGNADO { get; set; }
            public int cuenta { get; set; }
            public string UserName {get;set;}
        }
        public class Manejador : IRequestHandler<Contar, CONTEO> {
            private readonly CRMContext _context;
            private readonly IHubContext<ChatHub> _chatHub;
            public Manejador (CRMContext context, IHubContext<ChatHub> chatHub) {
                _context = context;
                _chatHub = chatHub;
            }

            public async Task<CONTEO> Handle(Contar request, CancellationToken cancellationToken)
            {
                var cont = await _context.NOTAS.Where(t => t.DestinatarioUserName == request.USUARIOASIGNADO && t.LEIDO == null).CountAsync ();
                var cuenta = new CONTEO {
                    USUARIOASIGNADO = request.USUARIOASIGNADO,
                    cuenta = cont
                };
                await _chatHub.Clients.Group(request.UserName).SendAsync ("CuentaNotasNoLeidas", cuenta);
                return cuenta;
            }
        }
    }
}