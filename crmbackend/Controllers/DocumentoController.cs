using System;
using System.Threading.Tasks;
using Aplicacion.Documentos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControladorGeneral {

        [HttpPost]
        public async Task<ActionResult<Unit>> GuardarArchivo (SubirArchivos.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ArchivoGenerico>> ObtenerDocumento (Guid id) {
            return await _mediator.Send (new ObtenerArchivo.Ejecuta { Id = id });
        }
    }
}