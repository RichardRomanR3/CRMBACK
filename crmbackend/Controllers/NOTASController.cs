using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONNOTAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [AllowAnonymous]
    public class NOTASController:ControladorGeneral {

        [HttpGet ("NOTASDELDIA")]
        public async Task<ActionResult<List<NOTAS>>> Listar () {
            return await _mediator.Send (new ListarNotasDelDia.Ejecuta ());
        }

        [HttpGet ("NOTASDELDIAUSUARIO/{usuario}")]
        public async Task<ActionResult<List<NOTAS>>> ListarNDU (string usuario) {
            return await _mediator.Send (new ListarNotasDelDiaUsuario.Ejecuta { UserName = usuario });
        }

        [HttpPost ("marcarComoLeido")]
        public async Task<ActionResult<Unit>> Crear (MarcarComoLeido.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpGet ("leidopor/{id}")]
        public async Task<ActionResult<List<V_LEIDO_POR>>> LeidoPor (Guid id) {
            return await _mediator.Send (new MostrarLeidoPor.Ejecuta { NOTA_ID = id });
        }

        [HttpGet ("difusionesPorFecha/{fecha}")]
        public async Task<ActionResult<List<NOTAS>>> ListarDPF (DateTime fecha) {
            return await _mediator.Send (new ListarDifusionesPorFecha.Ejecuta { FECGRA = fecha });
        }

        [HttpGet ("notasPorFecha/{fecha}/{usuario}")]
        public async Task<ActionResult<List<NOTAS>>> ListarNPF (DateTime fecha, string usuario) {
            return await _mediator.Send (new ListarNotasPorFecha.Ejecuta { FECGRA = fecha, DestinatarioUserName = usuario });
        }
         [HttpGet ("notasPorFechaEnv/{fecha}/{usuario}")]
        public async Task<ActionResult<List<NOTAS>>> ListarNPFENV (DateTime fecha, string usuario) {
            return await _mediator.Send (new ListarNotasPorFechaEnv.Ejecuta { FECGRA = fecha, RemitenteUserName = usuario });
        }

        [HttpGet ("NOTASDELDIAUSUARIOENV/{usuario}")]
        public async Task<ActionResult<List<NOTAS>>> ListarNDUENV (string usuario) {
            return await _mediator.Send (new ListarNotasDelDiaUsuarioEnv.Ejecuta { UserName = usuario });
        }
       

     
        //SE USA:
        //RRR: NOTIFICACIONES NABVAR
         [HttpPost("cuentaNotasNoLeidas")]
        public async Task<ActionResult<CONTEO>> ContarNotasNoLeidas (ContarNotasNoLeidas.Contar data) {
            return await _mediator.Send (data);
        }
           [HttpGet ("cuentaDifusionesDelDia")]
        public async Task<ActionResult<CONTEO>> ContarDifusionesDelDia () {
            return await _mediator.Send (new ContarDifusionesDelDia.Contar ());
        }

    }
}