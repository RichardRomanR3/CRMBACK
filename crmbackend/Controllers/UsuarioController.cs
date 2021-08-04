using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Seguridad;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControladorGeneral {
        
        [HttpGet ("lista")]
        public async Task<ActionResult<List<Usuarios>>> Lista () {
            return await _mediator.Send (new ConsultarUsuarios.Ejecuta ());
        }

        [HttpGet ("listaUsuariosPorRol/{rol}")]
        public async Task<ActionResult<List<Usuarios>>> ListaPorRol (string rol) {
            return await _mediator.Send (new ListarUsuarioPorRol.Ejecuta { RoleName = rol });
        }

        [HttpPut ("Role")]
        public async Task<ActionResult<Unit>> CambiarRoles () {
            return await _mediator.Send (new CambiarRol.Ejecuta ());
        }
         [HttpGet ("usuarioPorName/{UserName}")]
        public async Task<ActionResult<UsuarioData>> UsuxName (string UserName) {
            return await _mediator.Send (new ObtenerUsuarioPorName.Ejecuta { UserName = UserName });
        }


        //SE USA:

        //http://localhost:5000/api/Usuario/login
        [HttpPost ("login")]
        public async Task<ActionResult<UsuarioData>> Login (Login.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }
        [HttpGet]
        public async Task<ActionResult<UsuarioData>> DevolverUsuario () {
            return await _mediator.Send (new UsuarioActual.Ejecuta ());
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioData>> Actualizar (UsuarioActualizar.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }
         //http://localhost:5000/api/Usuario/registrar

        [HttpPost ("registrar")]
        public async Task<ActionResult<UsuarioData>> Registrar (RegistrarUsuario.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

          [HttpGet ("imagenesUsuarios/{user}")]
        public async Task<ActionResult<UsuarioData>> DevolverImgUsuario (string user) {
            return await _mediator.Send (new TraerImagenUsuario.Ejecuta { UserName = user });
        }

         [HttpPut("cambioClave")]
        public async Task<ActionResult<Unit>> ActualizarClave (CambioClave.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

        [HttpDelete("eliminarRol/{userName}")]

        public async Task<ActionResult<Unit>> Eliminar (string userName) {
            return await _mediator.Send (new UsuarioRolEliminar.Ejecuta { UserName = userName });
        }

    }
}