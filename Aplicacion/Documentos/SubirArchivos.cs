using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Documentos
{
    public class SubirArchivos
    {
        public class Ejecuta : IRequest{
            public Guid ObjetoReferencia {get;set;}
            public string Data {get;set;}
            public string Nombre {get;set;}
            public string Extension {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            public Manejador (CRMContext context){
                _context=context;
            }
            public async  Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var documento = await _context.Documento.Where(x=>x.ObjetoReferencia == request.ObjetoReferencia).FirstAsync();
                if(documento==null){
                    var doc = new Documento{
                      Contenido = Convert.FromBase64String(request.Data),
                      Nombre = request.Nombre,
                      Extension = request.Extension,
                      DocumentoId = Guid.NewGuid(),
                      FECGRA = DateTime.Now
                    };
                    _context.Documento.Add(doc);
                }else {
                    documento.Contenido = Convert.FromBase64String(request.Data);
                    documento.Nombre = request.Nombre;
                    documento.Extension = request.Extension;
                    documento.FECGRA = DateTime.Now;
                }
                var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                  return Unit.Value;  
                }
                throw new Exception("NO SE GUARDO LA IMAGEN");
            }
        }
    }
}