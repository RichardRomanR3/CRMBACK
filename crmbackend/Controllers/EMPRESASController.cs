using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONEMPRESAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class EMPRESASController : ControladorGeneral {

        [HttpGet]
        public async Task<ActionResult<List<Empresas>>> GetTask () {
            return await _mediator.Send (new ConsultaEmpresas.ListaEmpresas ());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Empresas>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaEmpresasPorId.EmpresaUnica { EMPRESA_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevaEmpresa.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarEmpresas.Ejecuta data) {
            data.EMPRESA_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarEmpresa.Ejecuta { EMPRESA_Id = id });
        }
    }
}