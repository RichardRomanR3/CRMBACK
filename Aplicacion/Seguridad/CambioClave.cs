using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class CambioClave
    {
        public class Ejecuta : IRequest{
            public string Email {get;set;}
            public string Password {get;set;}
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UserManager<Usuarios> _userManager;
            private readonly IPasswordHasher<Usuarios> _passwordHasher;
            public Manejador(UserManager<Usuarios> userManager,IPasswordHasher<Usuarios> passwordHasher){
                _userManager=userManager;
                _passwordHasher = passwordHasher;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync (request.Email);
                if(usuario!=null){
                usuario.PasswordHash = _passwordHasher.HashPassword (usuario, request.Password);
                var resultadoUpdate = await _userManager.UpdateAsync (usuario);
                if(resultadoUpdate.Succeeded){
                       return Unit.Value;
                }
                 throw new Exception ("No se puede registrar");
                }
                throw new Exception ("Email No existe");
             
            }
        }
    }
}