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
    public class UsuarioActual {
        public class Ejecuta : IRequest<UsuarioData> {

        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (UserManager<Usuarios> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion, CRMContext context, IMapper mapper) {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
                _context = context;
                _mapper = mapper;
            }
            public async Task<UsuarioData> Handle (Ejecuta request, CancellationToken cancellationToken) {
                
                var usuario = await _userManager.FindByNameAsync (_usuarioSesion.ObtenerUsuarioSesion ());
                var resultadoRoles = await _userManager.GetRolesAsync (usuario);
                var listaRoles = new List<string> (resultadoRoles);
                
                var ImagenPerfil = await _context.Documento.Where (x => x.ObjetoReferencia ==new Guid (usuario.Id)).FirstOrDefaultAsync ();

                var rolex = await _context.Roles
                .Include(x => x.PantallasLista)
                .ThenInclude(y => y.PANTALLA)
                .FirstOrDefaultAsync(a => a.Name == listaRoles[0]);

                var rolexdto = new RolDto();

                if(rolex!=null){
                rolexdto = _mapper.Map<Roles, RolDto>(rolex);
                }
                

                if (ImagenPerfil != null) {
                    var imagenCliente = new ImagenGeneral {
                    Data = Convert.ToBase64String (ImagenPerfil.Contenido),
                    Extension = ImagenPerfil.Extension,
                    Nombre = ImagenPerfil.Nombre
                    };
                    return new UsuarioData {
                            Id=usuario.Id,
                            UserName = usuario.UserName,
                            Token = _jwtGenerador.CrearToken (usuario, listaRoles),
                            Email = usuario.Email,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            ImagenPerfil = imagenCliente,
                            NUMEROTELEFONO = usuario.NUMEROTELEFONO,
                            RolesUsuario = listaRoles,
                            PantallasUsuario = rolexdto
                    };
                } else {
                    return new UsuarioData {
                            Id=usuario.Id,
                            UserName = usuario.UserName,
                            Token = _jwtGenerador.CrearToken (usuario, listaRoles),
                            Email = usuario.Email,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            ImagenPerfil = null,
                            NUMEROTELEFONO = usuario.NUMEROTELEFONO,
                            RolesUsuario = listaRoles,
                            PantallasUsuario = rolexdto
                    };
                }

            }
        }
    }
}