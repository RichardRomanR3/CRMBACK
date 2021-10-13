using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONMETRICAS;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class METRICASController : ControladorGeneral
    {
        [HttpGet("clientesPorCampana/{id}")]
        public async Task<ActionResult<List<CLIENTES>>> ListaClientes(Guid id)
        {
            return await _mediator.Send (new ConsultarClientesPorCampana.Ejecuta { CAMPANA_Id = id });
        }
        [HttpGet("campanaCAC/{id}")]
        public async Task<ActionResult<CAC>> CAC(Guid id)
        {
            return await _mediator.Send (new ConsultarCampanaPorIdMetricas.Ejecuta { CAMPANA_Id = id });
        }
    }
}