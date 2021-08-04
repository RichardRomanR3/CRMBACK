using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONSUGERENCIAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]

    public class SUGERENCIASController : ControladorGeneral
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevaSugerencia.Ejecuta data) {
            return await _mediator.Send (data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SUGERENCIAS>>> Listar (Guid id) {
            return await _mediator.Send (new ConsultarSugerenciasPorId.Ejecuta{cliente_id=id});
        }
         [HttpGet]
        public async Task<ActionResult<List<SUGERENCIASDto>>> ListarTodas () {
            return await _mediator.Send (new ListarSugerencias.Ejecuta());
        }
       [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, ModificarSugerencia.Ejecuta data) {
            data.Id = id;
            return await _mediator.Send (data);
        }

    };
}