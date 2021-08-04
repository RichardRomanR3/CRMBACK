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
    public class UsuarioActualizar {
        public class Ejecuta : IRequest<UsuarioData> {
            public string NOMBRECOMPLETO { get; set; }
            public string Email { get; set; }
            public string userName { get; set; }
            public string Password { get; set; }
            public string NUMEROTELEFONO { get; set; }
            public ImagenGeneral ImagenPerfil { get; set; }

        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData> {
            private readonly CRMContext _context;
            private readonly UserManager<Usuarios> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IPasswordHasher<Usuarios> _passwordHasher;
            private readonly IMapper _mapper;
            public Manejador (IJwtGenerador jwtGenerador, CRMContext context, UserManager<Usuarios> userManager, IPasswordHasher<Usuarios> passwordHasher,IMapper mapper) {
                _userManager = userManager;
                _context = context;
                _jwtGenerador = jwtGenerador;
                _passwordHasher = passwordHasher;
                _mapper=mapper;
            }
            public async Task<UsuarioData> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var usuario = await _userManager.FindByNameAsync (request.userName);
                if (usuario == null) {
                    throw new Exception ("EL USUARIO NO EXISTE");
                }
                var resultado = await _context.Users.Where (x => x.Email == request.Email && x.UserName != request.userName).AnyAsync ();
                if (resultado) {
                    throw new Exception ("ESE EMAIL PERTENECE A OTRO USUARIO");
                }
                if (request.ImagenPerfil != null) {
                    var resultadoImagen = await _context.Documento.Where (x => x.ObjetoReferencia ==new Guid (usuario.Id)).FirstOrDefaultAsync ();
                    if (resultadoImagen == null) {
                        var imagen = new Documento {
                        Contenido = System.Convert.FromBase64String (request.ImagenPerfil.Data),
                        Nombre = request.ImagenPerfil.Nombre,
                        Extension = request.ImagenPerfil.Extension,
                        ObjetoReferencia = new Guid(usuario.Id),
                        DocumentoId = Guid.NewGuid (),
                        FECGRA = DateTime.Now
                        };
                        _context.Documento.Add (imagen);
                    } else {
                        resultadoImagen.Contenido = System.Convert.FromBase64String (request.ImagenPerfil.Data);
                        resultadoImagen.Nombre = request.ImagenPerfil.Nombre;
                        resultadoImagen.Extension = request.ImagenPerfil.Extension;
                    }
                }

                usuario.NOMBRECOMPLETO = request.NOMBRECOMPLETO;
                usuario.PasswordHash = _passwordHasher.HashPassword (usuario, request.Password);
                usuario.Email = request.Email;
                usuario.NUMEROTELEFONO = request.NUMEROTELEFONO;
                var resultadoUpdate = await _userManager.UpdateAsync (usuario);
                var resultadoRoles = await _userManager.GetRolesAsync (usuario);
                var listaRoles = new List<string> (resultadoRoles);

                var imagenPerfil = await _context.Documento.Where (x => x.ObjetoReferencia == new Guid(usuario.Id)).FirstOrDefaultAsync ();
                
                var rolex = await _context.Roles
                .Include(x => x.PantallasLista)
                .ThenInclude(y => y.PANTALLA)
                .FirstOrDefaultAsync(a => a.Name == listaRoles[0]);

                var rolexdto = new RolDto();

                if(rolex!=null){
                rolexdto = _mapper.Map<Roles, RolDto>(rolex);
                }

                ImagenGeneral imagenGeneral = null;
                if (imagenPerfil != null) {
                    imagenGeneral = new ImagenGeneral {
                    Data = Convert.ToBase64String (imagenPerfil.Contenido),
                    Nombre = imagenPerfil.Nombre,
                    Extension = imagenPerfil.Extension
                    };

                }

                if (resultadoUpdate.Succeeded) {
                    return new UsuarioData {
                            Id=usuario.Id,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            UserName = usuario.UserName,
                            Token = _jwtGenerador.CrearToken (usuario, listaRoles),
                            Email = usuario.Email,
                            ImagenPerfil = imagenGeneral,
                            NUMEROTELEFONO = usuario.NUMEROTELEFONO,
                            RolesUsuario = listaRoles,
                            PantallasUsuario = rolexdto
                    };
                }
                throw new Exception ("No se pudo ACTUALIZAR Usuario");

            }
        }
    }
}