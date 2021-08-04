using System.Threading.Tasks;
using Aplicacion.ACCIONNOTAS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [AllowAnonymous]
    public class REALTIMEController : ControladorGeneral {

        [HttpPost ("difusion")]
        public async Task<ActionResult<Unit>> Create (NuevaDifusion.Ejecuta data) {
            return await _mediator.Send (data);
        }

        [HttpPost ("aUsuario")]

        public async Task<ActionResult<Unit>> CreateUsu (NuevaNota.Ejecuta data) {
            return await _mediator.Send (data);
        }

    }

}