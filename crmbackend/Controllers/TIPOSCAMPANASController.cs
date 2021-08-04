using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONTIPOSCAMPANAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class TIPOSCAMPANASController : ControladorGeneral {

        [HttpGet]
        public async Task<ActionResult<List<TIPOSCAMPANAS>>> GetTask () {
            return await _mediator.Send (new ConsultaTiposCampanas.ListaTiposCampanas ());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<TIPOSCAMPANAS>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaTiposCampanasPorId.TipoCampanaUnica { TIPOCAMPANA_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevoTipoCampana.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarTiposCampanas.Ejecuta data) {
            data.TIPOCAMPANA_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarTipoCampana.Ejecuta { TIPOCAMPANA_Id = id });
        }
    }
}