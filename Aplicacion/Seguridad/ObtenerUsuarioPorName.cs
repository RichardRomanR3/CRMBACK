using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Aplicacion.Seguridad
{
    public class ObtenerUsuarioPorName
    {
        public class Ejecuta : IRequest<UsuarioData>{
            public string UserName {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
           private readonly UserManager<Usuarios> _userManager;
            public Manejador(UserManager<Usuarios> userManager){
_userManager=userManager;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario= await _userManager.FindByNameAsync(request.UserName);
                return new UsuarioData {
                            UserName = usuario.UserName,
                            Email = usuario.Email,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            NUMEROTELEFONO = usuario.NUMEROTELEFONO
                    };
            }
        }
    }
}