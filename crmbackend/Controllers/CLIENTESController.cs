using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.ACCIONBARRIOS;
using Aplicacion.ACCIONCIUDADES;
using Aplicacion.ACCIONCLIENTES;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class CLIENTESController : ControladorGeneral {

        
        [HttpGet ("{id}")]
        public async Task<ActionResult<Dominio.CLIENTES>> Detalle (Guid id) {
            return await _mediator.Send (new ConsultaClientesPorId.ClienteUnico { CLIENTE_Id = id });
        }

        [HttpGet ("consultarporci/{ci}")]
        public async Task<ActionResult<List<Dominio.CLIENTES>>> DetalleCOD (string ci) {
            return await _mediator.Send (new ConsultarClientePorCI.ClienteUnico { CI = ci });
        }
        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> Eliminar (Guid id) {
            return await _mediator.Send (new EliminarCliente.Ejecuta { CLIENTE_Id = id });
        }

        [HttpGet ("redes/{id}")]
        public async Task<ActionResult<List<REDES_CLIENTESDto>>> ListarRedes (Guid id) {
            return await _mediator.Send (new ConsultarRedesCliente.Ejecuta { CLIENTE_Id = id });
        }

   
        [HttpDelete ("eliminartelefono/{id}")]
        public async Task<ActionResult<Unit>> EliminarTelefono (Guid id) {
            return await _mediator.Send (new EliminarTelefono.Ejecuta { TELEFONO_Id = id });
        }

        [HttpDelete ("eliminarred/{id}")]
        public async Task<ActionResult<Unit>> EliminarRed (Guid id) {
            return await _mediator.Send (new EliminarRed.Ejecuta { RED_Id = id });
        }
        [HttpGet]
        public async Task<ActionResult<List<CLIENTESDto>>> GetTask () {
            return await _mediator.Send (new ConsultaClientes.ListaClientes ());
        }

           [HttpPost]
        public async Task<ActionResult<Unit>> Crear (NuevoCliente.Ejecuta data) {
            return await _mediator.Send (data);
        }
            [HttpGet ("barrios/{id}")]
        public async Task<ActionResult<List<BARRIOSDto>>> ListarBarrios (Guid id) {
            return await _mediator.Send (new ConsultarBarrios.ListarBarrios { CIUDAD_Id = id });
        }
             [HttpGet ("ciudades")]
        public async Task<ActionResult<List<CIUDADES>>> ListarCiudades () {
            return await _mediator.Send (new ConsultarCiudades.ListarCiudades ());
        }
           [HttpDelete ("eliminardireccion/{id}")]
        public async Task<ActionResult<Unit>> EliminarDireccion (Guid id) {
            return await _mediator.Send (new EliminarDirecciones.Ejecuta { DIRECCION_Id = id });
        }

             [HttpGet ("direcciones/{id}")]
        public async Task<ActionResult<List<DIRECCIONESDto>>> ListarDirecciones (Guid id) {
            return await _mediator.Send (new ConsultarDirecciones.ListarDirecciones { CLIENTE_Id = id });
        }
         [HttpPut ("{id}")]
        public async Task<ActionResult<Unit>> Editar (Guid id, EditarClientes.Ejecuta data) {
            data.CLIENTE_Id = id;
            return await _mediator.Send (data);
        }
           [HttpGet ("telefonos/{id}")]
        public async Task<ActionResult<List<TELEFONOSDto>>> ListarTelefonos (Guid id) {
            return await _mediator.Send (new ConsultarTelefonos.ListarTelefonos { CLIENTE_Id = id });
        }
          [HttpGet ("tareascliente/{id}")]
        public async Task<ActionResult<List<TAREASDto>>> TareasCliente (Guid id) {
            return await _mediator.Send (new ObtenerTareasClientes.Ejecuta { ClienteId = id });
        }

         
         
    }
}