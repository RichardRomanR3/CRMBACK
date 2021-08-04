using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONPOSIBLESCLIENTES;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class POSIBLESCLIENTESController : ControladorGeneral {

        [HttpGet ("listarposiblesclientes/{usuario}")]
        public async Task<ActionResult<List<POSIBLESCLIENTES>>> GetTask (string usuario) {
            return await _mediator.Send (new ConsultaPosiblesClientes.ListaPosiblesClientes { USUARIO = usuario });
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<POSIBLESCLIENTES>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaPosiblesClientesPorId.PosibleClienteUnico { POSIBLECLIENTE_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevoPosibleCliente.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarPosiblesClientes.Ejecuta data) {
            data.POSIBLECLIENTE_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarPosibleCliente.Ejecuta { POSIBLECLIENTE_Id = id });
        }
    }
}