using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad {
    public class Login {
        public class Ejecuta : IRequest<UsuarioData> {
            public string Email { get; set; }
            public string Password { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly SignInManager<Usuarios> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager, IJwtGenerador jwtGenerador, CRMContext context, IMapper mapper) {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
                _context = context;
                _mapper = mapper;
            }
            public async Task<UsuarioData> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var usuario = await _userManager.FindByEmailAsync (request.Email);
                if (usuario == null) {
                    throw new Exception ("no se pudo");
                }
                var resultado = await _signInManager.CheckPasswordSignInAsync (usuario, request.Password, false);
                var resultadoRoles = await _userManager.GetRolesAsync (usuario);
                var listaRoles = new List<string> (resultadoRoles);
                var imagenPerfil = await _context.Documento.Where (x => x.ObjetoReferencia == new Guid (usuario.Id)).FirstOrDefaultAsync ();
               
                var rolex = await _context.Roles
                .Include(x => x.PantallasLista)
                .ThenInclude(y => y.PANTALLA)
                .FirstOrDefaultAsync(a => a.Name == listaRoles[0]);

                var rolexdto = new RolDto();

                if(rolex!=null){
                rolexdto = _mapper.Map<Roles, RolDto>(rolex);
                }
                
                if (resultado.Succeeded) {
                    if (imagenPerfil != null) {
                        var imagenCliente = new ImagenGeneral {
                        Data = Convert.ToBase64String (imagenPerfil.Contenido),
                        Extension = imagenPerfil.Extension,
                        Nombre = imagenPerfil.Nombre
                        };
                        return new UsuarioData {
                                Id=usuario.Id,
                                NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                                Token = _jwtGenerador.CrearToken (usuario, listaRoles),
                                UserName = usuario.UserName,
                                Email = usuario.Email,
                                ImagenPerfil = imagenCliente,
                                NUMEROTELEFONO = usuario.NUMEROTELEFONO,
                                RolesUsuario = listaRoles,
                                PantallasUsuario = rolexdto
                        };
                    } else {
                        return new UsuarioData {
                                Id=usuario.Id,
                                NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                                Token = _jwtGenerador.CrearToken (usuario, listaRoles),
                                UserName = usuario.UserName,
                                Email = usuario.Email,
                                Password = " ",
                                Confirmarpassword = " ",
                                NUMEROTELEFONO = usuario.NUMEROTELEFONO,
                                RolesUsuario = listaRoles,
                                PantallasUsuario = rolexdto
                        };
                    }
                }
                throw new Exception ("desautorizado");
            }
        }
    }
}