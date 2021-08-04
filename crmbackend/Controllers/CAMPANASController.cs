using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONCAMPANAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    //localhost:5000/api/CAMPANAS
    [Route ("api/[controller]")]
    [ApiController]

    public class CAMPANASController : ControladorGeneral {
        

        [HttpGet ("{id}")]
        public async Task<ActionResult<CAMPANAS>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaCampanasPorId.CampanaUnica { CAMPANA_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevaCampana.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarCampanas.Ejecuta data) {
            data.CAMPANA_Id = id;
            return await _mediator.Send (data);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarCampana.Ejecuta { CAMPANA_Id = id });
        }

        [HttpGet ("ClientesPorCampana/{id}")]
        public async Task<ActionResult<List<CLIENTESDto>>> ClientesPorCampana (Guid id) {
            return await _mediator.Send (new ObtenerClientesPorCampana.Ejecuta { CAMPANA_Id = id });
        }

        [HttpGet ("Alcance/{id}")]
        public async Task<ActionResult<CONTEO>> Contar (Guid id) {
            return await _mediator.Send (new ContarClientesPorCampana.Ejecuta { CAMPANA_Id = id });
        }

        [HttpPost ("AlcancePorFecha")]
        public async Task<ActionResult<CONTEO>> ContarPorFecha (ContarClientesPorCampanaPorFecha.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPost ("ClientesPorCampanaFecha")]
        public async Task<ActionResult<List<CLIENTESDto>>> ClientesPorCampanaFecha (ObtenerClientesPorCampanaFecha.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CAMPANASDto>>> GetTask () {
            return await _mediator.Send (new ConsultaCampanas.ListaCampanas ());
        }


    }
}