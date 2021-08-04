using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONCONTACTOS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class CONTACTOSController : ControladorGeneral {

        [HttpGet ("listarcontactos/{usuarioid}")]
        public async Task<ActionResult<List<CONTACTOSDto>>> GetTask (string usuarioid) {
            return await _mediator.Send (new ConsultaContactos.ListaContactos { USUARIOId = usuarioid });
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CONTACTOS>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaContactosPorId.ContactoUnico { CONTACTO_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevoContacto.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarContactos.Ejecuta data) {
            data.CONTACTO_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarContacto.Ejecuta { CONTACTO_Id = id });
        }
    }
}