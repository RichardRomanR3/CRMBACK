using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Documentos
{
    public class ObtenerArchivo
    {
        public class Ejecuta : IRequest<ArchivoGenerico>
        {
            public Guid Id{get;set;}
            

        }
        public class Manejador : IRequestHandler<Ejecuta, ArchivoGenerico>
        {
            private readonly CRMContext _context;
            
            public Manejador(CRMContext context)
            {
                    _context = context;
            }
            public async Task<ArchivoGenerico> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var archivo = await _context.Documento.Where(x=>x.ObjetoReferencia == request.Id).FirstAsync();
                if (archivo == null)
                {
                    throw new Exception("NO SE ENCONTRO LA IMAGEN");
                }
                var archivoGenerico = new ArchivoGenerico{
                    Data = Convert.ToBase64String(archivo.Contenido),
                    Nombre= archivo.Nombre,
                    Extension = archivo.Extension
                };
                return archivoGenerico;

            }
        }

    }
}