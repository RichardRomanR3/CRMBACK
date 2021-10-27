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

         [HttpGet ("graficoTareas")]
        public async Task<ActionResult<List<GRAFICO_TAREAS>>> GRAFICO_TAREAS (string id) {
            return await _mediator.Send (new ConsultarGraficoDeTareas.Ejecuta());
        }
         [HttpGet ("graficoCampanas")]
        public async Task<ActionResult<List<GRAFICO_CAMPANAS>>> GRAFICO_CAMPANAS (string id) {
            return await _mediator.Send (new ConsultarGraficoCampanas.Ejecuta());
        }
    }
}