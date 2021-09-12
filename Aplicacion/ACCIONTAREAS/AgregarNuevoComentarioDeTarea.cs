using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONTAREAS
{
    public class AgregarNuevoComentarioDeTarea
    {
        public class Ejecuta : IRequest
        {
            public Guid TAREA_Id { get; set; }
            public string comentario { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            public Manejador(CRMContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _comentarioId = Guid.NewGuid();
                var comentarios = new COMENTARIOSDETAREAS
                {
                    comentarioId = _comentarioId,
                    comentario = request.comentario,
                    FECGRA = DateTime.Now,
                    TAREAId = request.TAREA_Id,
                };
                _context.COMENTARIOSDETAREAS.Add(comentarios);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los datos");
            }
        }
    }
}