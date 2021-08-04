using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion {
    public class ModificarAlerta {
        public class Ejecuta : IRequest {
            public string UsuarioId { get; set; }
            public int? minutosalerta { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var a = await _context.ALERTAS.Where(x => x.UsuarioId == request.UsuarioId).FirstAsync();
                var alerta = await _context.ALERTAS.FindAsync(a.Id);
                alerta.minutosalerta = request.minutosalerta ?? alerta.minutosalerta;
                var resultado = await _context.SaveChangesAsync ();
                if (resultado > 0)
                    return Unit.Value;
                throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
            }
        }

    }
}