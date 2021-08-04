using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace crmbackend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ControladorGeneral:ControllerBase
    {
        private IMediator mediator;
        protected IMediator _mediator => mediator ?? (mediator=HttpContext.RequestServices.GetService<IMediator>());
    }
}