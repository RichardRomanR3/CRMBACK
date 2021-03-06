using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class RegistrarUsuario
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string NOMBRECOMPLETO { get; set; }
            public string UserName { get; set; }
            public string NOMBRE { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string NUMEROTELEFONO { get; set; }

            public string RolNombre { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuarios> _userManager;
            private readonly CRMContext _context;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly RoleManager<Roles> _roleManager;

            public Manejador(CRMContext context, UserManager<Usuarios> userManager, IJwtGenerador jwtGenerador, RoleManager<Roles> roleManager)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _roleManager = roleManager;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                var existeuser = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                var rol = await _roleManager.FindByNameAsync(request.RolNombre);

                if (existe)
                {
                    throw new Exception("YA EXISTE UN USUARIO CON ESE EMAIL");
                }
                else if (existeuser)
                {
                    throw new Exception("YA EXISTE UN USUARIO CON ESE ALIAS");
                }
                var nuevoId = Guid.NewGuid();
                var usuario = new Usuarios
                {
                    Id = nuevoId.ToString(),
                    NOMBRECOMPLETO = request.NOMBRECOMPLETO,
                    UserName = request.UserName,
                    Email = request.Email,
                    FECGRA = DateTime.Now,
                    NUMEROTELEFONO = request.NUMEROTELEFONO
                };
                var resultado = await _userManager.CreateAsync(usuario, request.Password);

                if (resultado.Succeeded)
                    if (rol == null)
                    {
                        throw new Exception("EL ROL NO EXISTE");
                    }
                var usuarioRol = await _userManager.FindByNameAsync(request.UserName);
                if (usuarioRol == null)
                {
                    throw new Exception("NO EXISTE EL USUARIO");
                }
                var resultadoRol = await _userManager.AddToRoleAsync(usuarioRol, request.RolNombre);
                if (!resultadoRol.Succeeded)
                {
                throw new Exception("No se pudo registrar Rol");
                }
                Guid alertaId = Guid.NewGuid();
                var alerta = new ALERTAS
                {
                    Id = alertaId,
                    UsuarioId = nuevoId.ToString(),
                    minutosalerta = 10
                };
                var resultadoAlerta = await _context.ALERTAS.AddAsync(alerta);
                await _context.SaveChangesAsync();
                return new UsuarioData
                {
                    NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                    Token = _jwtGenerador.CrearToken(usuario, null),
                    UserName = usuario.UserName,
                    Email = usuario.Email,
                    NUMEROTELEFONO = usuario.NUMEROTELEFONO
                };

                throw new Exception("No se pudo registrar");
            }
        }
    }
}