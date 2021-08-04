using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace Aplicacion.ACCIONEXCEL
{  
  public interface IExcel {
        Task<List<CLIENTES>> ImportarExcelCLIENTES (IFormFile file);
        Task<List<POSIBLESCLIENTES>> ImportarExcelPOSIBLESCLIENTES (IFormFile file);

    }
}