using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Persistencia;

namespace Aplicacion.ACCIONNOTAS {
    public class NuevaNota {
        public class Ejecuta : IRequest {
            public string Texto { get; set; }
            public string RemitenteUserName { get; set; }
            public string DestinatarioUserName { get; set; }
            public string DIFUSION { get; set; }
            public DateTime FECGRA { get; set; }
            public string ArchivoUrl { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {

            private readonly CRMContext _context;
            private readonly IHubContext<ChatHub> _chatHub;
            public Manejador (CRMContext context, IHubContext<ChatHub> chatHub) {
                _context = context;
                _chatHub = chatHub;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                Guid _notaId = Guid.NewGuid ();
                var nota = new NOTAS {
                    NOTA_Id = _notaId,
                    Texto = request.Texto,
                    RemitenteUserName = request.RemitenteUserName,
                    DestinatarioUserName = request.DestinatarioUserName,
                    DIFUSION = request.DIFUSION,
                    FECGRA = DateTime.Now,
                    ArchivoUrl = request.ArchivoUrl
                };
                await _chatHub.Clients.Group(request.DestinatarioUserName).SendAsync ("EnviandoUsu", nota);
                _context.NOTAS.Add (nota);
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                throw new Exception ("No se guardaron los datos");

            }
        }
    }
}