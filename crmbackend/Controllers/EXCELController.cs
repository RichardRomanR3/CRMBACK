using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONEXCEL;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace crmbackend.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [AllowAnonymous]
    public class EXCELController : ControladorGeneral {
       
        [HttpPost("CLIENTES")]
        public async Task<ActionResult<Unit>> InsertarExcelACLIENTES ( [FromForm]  ExcelADBCLIENTES.Ejecuta file) { 
          return await _mediator.Send (file);  
        }

           [HttpPost("POSIBLESCLIENTES")]
        public async Task<ActionResult<Unit>> InsertarExcelAPOSIBLESCLIENTES ( [FromForm]  ExcelADBPOSIBLESCLIENTES.Ejecuta file) { 
          return await _mediator.Send (file);  
        }
           [HttpGet("ArchivosClientes/{fecha}")]
         public async Task<ActionResult<List<V_ARCHIVOS_CLIENTES>>> ArchivosClientes (DateTime fecha) {
            return await _mediator.Send (new ConsultarArchivosClientes.Ejecuta { fecha=fecha });
        }
      
           [HttpGet("ArchivosPosiblesClientes/{fecha}")]
         public async Task<ActionResult<List<V_ARCHIVOS_POSIBLESCLIENTES>>> ArchivosPosiblesClientes (DateTime fecha) {
            return await _mediator.Send (new ConsultarArchivosPosiblesClientes.Ejecuta { fecha=fecha });
        }
           [HttpGet("ExistenciaClientes/{nombre}")]
         public async Task<ActionResult<List<CLIENTES>>> ExistenciaClientes (string nombre) {
            return await _mediator.Send (new ConsultarExcelPorNombreClientes.Ejecuta {nombreArchivo=nombre });
        }
         [HttpGet("ExistenciaPosiblesClientes/{nombre}")]
         public async Task<ActionResult<List<POSIBLESCLIENTES>>> ExistenciaPosiblesClientes (string nombre) {
            return await _mediator.Send (new ConsultarExcelPorNombrePosiblesClientes.Ejecuta {nombreArchivo=nombre });
        }         
            

         [HttpDelete ("RevertirExcelCLIENTES/{nombre}/{fecha}")]
        public async Task<ActionResult<Unit>> EliminarClientes (string nombre,DateTime fecha) {
            return await _mediator.Send (new EliminarPorArchivosClientes.Ejecuta { nombreArchivo = nombre,fecgra=fecha });
        }

        [HttpDelete ("RevertirExcelPOSIBLESCLIENTES/{nombre}/{fecha}")]
        public async Task<ActionResult<Unit>> EliminarPosiblesClientes (string nombre,DateTime fecha) {
            return await _mediator.Send (new EliminarPorArchivosPosiblesClientes.Ejecuta { nombreArchivo = nombre,fecgra=fecha });
        }
    }
}