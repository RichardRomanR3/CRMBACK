using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Seguridad;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]

    public class PantallasController
    {
        private readonly IMediator _mediator;
        public PantallasController (IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet ("lista")]
        public async Task<ActionResult<List<PANTALLAS>>> Lista () {
            return await _mediator.Send (new PantallasLista.Ejecuta ());
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<List<CategoriaDto>>> ListaCategorias () {
            return await _mediator.Send (new ListaCategorias.Ejecuta ());
        }

        
    }
}