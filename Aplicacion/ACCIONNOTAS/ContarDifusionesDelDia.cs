using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONNOTAS {
    public class ContarDifusionesDelDia {
        public class Contar : IRequest<CONTEO> {
            public string USUARIOASIGNADO { get; set; }
            public int cuenta { get; set; }
        }
        public class Manejador : IRequestHandler<Contar, CONTEO> {
            private readonly CRMContext _context;
            private readonly IHubContext<ChatHub> _chatHub;
            public Manejador (CRMContext context , IHubContext<ChatHub> chatHub) {
                _context = context;
                _chatHub = chatHub;
            }

            public async Task<CONTEO> Handle(Contar request, CancellationToken cancellationToken)
            {
                    var cont = await _context.NOTAS.Where (t => t.DIFUSION == "SI" && t.FECGRA.Date == DateTime.Now.Date).CountAsync ();
                var cuenta = new CONTEO {
                    USUARIOASIGNADO = null,
                    cuenta = cont
                };
          await _chatHub.Clients.All.SendAsync("CuentaDifusionesDelDia", cuenta);
                return cuenta;
                throw new NotImplementedException ();
            }
        }
    }
}