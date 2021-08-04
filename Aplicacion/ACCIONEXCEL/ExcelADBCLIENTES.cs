using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONEXCEL {
    public class ExcelADBCLIENTES {
        public class Ejecuta : IRequest {
            public IFormFile file { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta> {
            private readonly CRMContext _context;
            private readonly IExcel _importar;
            public Manejador (IExcel importar, CRMContext context) {
                _importar = importar;
                _context = context;
            }
            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var lista = await _importar.ImportarExcelCLIENTES (request.file);
                for (int row = lista.Count -1 ;row >=0;row--){
                    var existe = await _context.CLIENTES.Where(x=>x.CI == lista[row].CI || x.RUC == lista[row].RUC).AnyAsync();
                      if(existe){
                           lista.RemoveAt(row);
                         }  
                };
                _context.CLIENTES.AddRange(lista); 
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                    return Unit.Value;
            }
        }
    }
}