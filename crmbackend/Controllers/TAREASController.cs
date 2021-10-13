using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONCLIENTES;
using Aplicacion.ACCIONNOTAS;
using Aplicacion.ACCIONTAREAS;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TAREASController : ControladorGeneral
    {

        [HttpGet]
        public async Task<ActionResult<List<TAREASGENERALESDto>>> GetTask()
        {
            return await _mediator.Send(new ConsultaTareas.ListaTareas());
        }

        [HttpGet("tareasAsignadasPor/{usuario}")]
        public async Task<ActionResult<List<TAREASGENERALESDto>>> GetTareasAsig(string usuario)
        {
            return await _mediator.Send(new ConsultaTareasGeneralesAsigPor.ListaTareas { ASIGNADOPOR = usuario });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TAREASGENERALESDto>>> Detalle(Guid id)
        {
            return await _mediator.Send(new ConsultaTareasPorId.TareaUnica { TAREA_Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevaTarea.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarTareas.Ejecuta data)
        {
            data.TAREA_Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await _mediator.Send(new EliminarTarea.Ejecuta { TAREA_Id = id });
        }

        [HttpGet("lista/{usuarioasignado}")]
        public async Task<ActionResult<List<TAREASGENERALESDto>>> Lista(string usuarioasignado)
        {
            return await _mediator.Send(new ConsultaTareaGeneral.ListarTareasGenerales { USUARIOASIGNADO = usuarioasignado });
        }

        [HttpGet("cuentaNotasNoLeidas/{usuarioasignado}")]
        public async Task<ActionResult<CONTEO>> ContarNotasNoLeidas(string usuarioasignado)
        {
            return await _mediator.Send(new ContarNotasNoLeidas.Contar { USUARIOASIGNADO = usuarioasignado });
        }

        [HttpGet("cuentaDifusionesDelDia")]
        public async Task<ActionResult<CONTEO>> ContarDifusionesDelDia()
        {
            return await _mediator.Send(new ContarDifusionesDelDia.Contar());
        }


        [HttpGet("tareasdeldia/{usuario}")]
        public async Task<ActionResult<List<TAREASGENERALESDto>>> ContarTareasDelDia(string usuario)
        {
            return await _mediator.Send(new ConsultarTareasDelDia.Consultar { USUARIOASIGNADO = usuario });
        }

        [HttpGet("ultimatarea")]
        public async Task<ActionResult<ULTIMO>> Mostrar()
        {
            return await _mediator.Send(new TraerUltimaTarea.Ejecuta());
        }

        [HttpGet("telefonosclientes/{id}")]
        public async Task<ActionResult<List<TELEFONOS>>> ListarTelefonoliente(Guid id)
        {
            return await _mediator.Send(new ConsultarTelefonoCliente.Ejecuta { CLIENTE_Id = id });
        }

        [HttpGet("telefonos/{id}")]
        public async Task<ActionResult<List<TELEFONOSTAREASDto>>> ListarTelefonos(Guid id)
        {
            return await _mediator.Send(new ConsultarTelefonosTareas.ListarTelefonosTareas { TAREA_Id = id });
        }

        [HttpGet("direcciones/{id}")]
        public async Task<ActionResult<List<DIRECCIONESTAREASDto>>> ListarDirecciones(Guid id)
        {
            return await _mediator.Send(new ConsultarDireccionesTareas.ListarDireccionesTareas { TAREA_Id = id });
        }



        //SE USA:
        //RRR: NOTIFICACION EN NABVAR 
        [HttpPost("cuenta")]
        public async Task<ActionResult<CONTEO>> Contar(ContarTareasPendientes.Contar data)
        {
            return await _mediator.Send(data);
        }
         [HttpPost("cuentaCerradasPropias")]
        public async Task<ActionResult<CONTEO>> ContarCerradas(ContarTareasCerradas.Contar data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("COMENTARIOSDETAREA/{id}")]
        public async Task<ActionResult<List<COMENTARIOSDETAREAS>>> ListarComentarios(Guid id)
        {
            return await _mediator.Send(new ListarComentariosDeTarea.Ejecuta { TAREA_Id = id });
        }
            [HttpPost("NUEVOCOMENTARIODETAREA")]
        public async Task<ActionResult<Unit>> Comentar (AgregarNuevoComentarioDeTarea.Ejecuta data)
        {
            return await _mediator.Send(data);
        }


    }
}