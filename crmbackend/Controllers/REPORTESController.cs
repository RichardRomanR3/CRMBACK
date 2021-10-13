using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONREPORTES;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class REPORTESController : ControladorGeneral
    {
        [HttpGet ("eventos/{id}")]
        public async Task<ActionResult<List<EVENTOCALENDARIO>>> EVENTOS (string id) {
            return await _mediator.Send (new ConsultarEventosCalendario.Ejecuta{UsuarioId=id});
        }
    }
}