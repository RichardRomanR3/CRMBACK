using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONEXCEL
{
    public class ExcelADBPOSIBLESCLIENTES
    {
        public class Ejecuta : IRequest{
            public string UserName {get;set;}
             public IFormFile file { get; set; }
             public string fileName {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CRMContext _context;
            private readonly IExcel _importar;
            private readonly UserManager<Usuarios> _userManager;
            public Manejador(CRMContext context,IExcel importar,UserManager<Usuarios> userManager){
                _context=context;
                _importar=importar;
                _userManager=userManager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(request.UserName);
                var lista = await _importar.ImportarExcelPOSIBLESCLIENTES(request.file);
                for (int row = lista.Count -1 ;row >=0;row--){
                    var existe = await _context.CLIENTES.Where(x=>x.CI == lista[row].CI || x.RUC == lista[row].RUC).AnyAsync();
                      if(existe){
                           lista.RemoveAt(row);
                         }  
                };
                for (int row = lista.Count -1 ;row >=0;row--){
                     lista[row].UsuarioId=usuario.Id; 
                     lista[row].NombreArchivo=request.fileName;  
                 }
                _context.POSIBLESCLIENTES.AddRange(lista); 
                var valor = await _context.SaveChangesAsync ();
                if (valor > 0) {
                    return Unit.Value;
                }
                    return Unit.Value;
            }
        }
    }
}