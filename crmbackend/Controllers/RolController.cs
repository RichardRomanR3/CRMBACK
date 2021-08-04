using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Seguridad;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class RolController : ControladorGeneral {
        [HttpPost ("crear")]
        public async Task<ActionResult<Unit>> Crear (RolNuevo.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

        [HttpPut ("modificar")]
        public async Task<ActionResult<Unit>> Modificar (RolModificar.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new RolEliminar.Ejecuta { Id = id });
        }

        [HttpGet ("lista")]
        public async Task<ActionResult<List<Roles>>> Lista () {
            return await _mediator.Send (new RolLista.Ejecuta ());
        }

        [HttpPost ("agregarRolUsuario")]
        public async Task<ActionResult<Unit>> AgregarRolUsuario (UsuarioRolAgregar.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }
        //RICHARD : se envia el usuario y el rol para eliminar(elimina solo el rol que tiene asignado ese usuario)
        [HttpPost ("eliminarRolUsuario")]
        public async Task<ActionResult<Unit>> EliminarRolUsuario (UsuarioRolEliminar.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }

        [HttpGet ("{username}")]
        public async Task<ActionResult<List<string>>> ObtenerRolesPorUsuarios (string username) {
            return await _mediator.Send (new ListarRolesUsuarios.Ejecuta { UserName = username });
        }
         [HttpPost ("asignarPermisosRoles")]
        public async Task<ActionResult<Unit>> AsignarPermisos (AsignarPantallasARoles.Ejecuta parametros) {
            return await _mediator.Send (parametros);
        }
         [HttpDelete ("{idRol}/{idPantalla}")]
        public async Task<ActionResult<Unit>> EliminarPermiso ( string idRol,Guid idPantalla) {
            return await _mediator.Send (new EliminarPermisos.Ejecuta { ROL_Id=idRol,PANTALLA_Id=idPantalla });
        }

        [HttpGet("roldetalle/{id}")]
        public async Task<ActionResult<RolDto>> RolDetalle(string id){
            return await _mediator.Send(new PantallasDelRol.Ejecuta{codrol = id});
        }

        [HttpPost("roldetalle2")]
        public async Task<ActionResult<RolDto>> RolDetalle2(PantallasDelRol.Ejecuta parametros){
            return await _mediator.Send(parametros);
        }
    }
}