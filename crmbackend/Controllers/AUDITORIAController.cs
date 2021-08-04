using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONAUDITORIA;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AUDITORIAController : ControladorGeneral
    {  
         [HttpPost ("registroAuditoria")]
        public async Task<ActionResult<Unit>> NuevaAudit (NuevaAuditoria.Ejecuta data) {
            return await _mediator.Send (data);
        }
        [HttpGet]
        public async Task<ActionResult<List<AUDITORIA>>> ListaAudi (){
            return await _mediator.Send(new MostrarMovimientos.Ejecuta());
        }
        
    }
}