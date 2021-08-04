using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONTIPOTAREAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class TIPOSTAREASController : ControladorGeneral {

        [HttpGet]
        public async Task<ActionResult<List<TIPOSTAREAS>>> GetTask () {
            return await _mediator.Send (new ConsultaTiposTareas.ListaTiposTareas ());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<TIPOSTAREAS>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaTiposTareasPorId.TipoTareaUnica { TIPOTAREA_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevoTipoTarea.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarTiposTareas.Ejecuta data) {
            data.TIPOTAREA_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarTipoTarea.Ejecuta { TIPOTAREA_Id = id });
        }

    }
}