using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONNOTAS {
    public class MarcarComoLeido {
        public class Ejecuta : IRequest {
            public string DIFUSION { get; set; }
            public string NOMBRECOMPLETO { get; set; }
            public Guid NOTA_Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {

            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                if (request.DIFUSION == "SI") {
                    Guid dif = Guid.NewGuid ();
                    var nota = await _context.NOTAS.FindAsync (request.NOTA_Id);
                    var difusionesleidas = new DIFUSIONESLEIDAS {
                        DIFUSION_ID = dif,
                        NOTA = nota,
                        LEIDOPOR = request.NOMBRECOMPLETO,
                        FECHALEIDA = DateTime.Now
                    };
                    _context.DIFUSIONESLEIDAS.Add (difusionesleidas);
                    var valor = await _context.SaveChangesAsync ();
                    if (valor > 0)
                        return Unit.Value;
                    throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
                } else {
                    var NOTA = await _context.NOTAS.FindAsync (request.NOTA_Id);
                    NOTA.LEIDO = DateTime.Now;
                    var resultado = await _context.SaveChangesAsync ();
                    if (resultado > 0)
                        return Unit.Value;
                    throw new Exception ("NO SE GUARDARON LOS DATOS LPM");
                }
            }
        }

    }
}