using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion;
using Aplicacion.ACCIONALERTAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
      [Route ("api/[controller]")]
      [ApiController]
    public class ALERTASController : ControladorGeneral 
    {
        [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (string id, ModificarAlerta.Ejecuta data) {
            data.UsuarioId = id;
            return await _mediator.Send (data);
        }
         [HttpGet ("{id}")]
        public async Task<ActionResult<List<ALERTAS>>> ListarDirecciones (string id) {
            return await _mediator.Send (new AlertaPorUsuario.Ejecuta { UsuarioId = id });
        }
    }
}