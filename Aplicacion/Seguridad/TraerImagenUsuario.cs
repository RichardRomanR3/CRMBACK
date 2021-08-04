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

namespace Aplicacion.Seguridad {
    public class TraerImagenUsuario {
        public class Ejecuta : IRequest<UsuarioData> {
            public string UserName { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData> {
            private readonly UserManager<Usuarios> _userManager;
            private readonly CRMContext _context;
            public Manejador (UserManager<Usuarios> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion, CRMContext context) {
                _userManager = userManager;
                _context = context;
            }

            public async Task<UsuarioData> Handle (Ejecuta request, CancellationToken cancellationToken) {
                var usuario = await _userManager.FindByNameAsync (request.UserName);
                var ImagenPerfil = await _context.Documento.Where (x => x.ObjetoReferencia ==  new Guid(usuario.Id)).FirstOrDefaultAsync ();
                if (ImagenPerfil != null) {
                    var imagenCliente = new ImagenGeneral {
                    Data = Convert.ToBase64String (ImagenPerfil.Contenido),
                    Extension = ImagenPerfil.Extension,
                    Nombre = ImagenPerfil.Nombre
                    };
                    return new UsuarioData {
                        UserName = usuario.UserName,
                            Token = null,
                            Email = null,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            ImagenPerfil = imagenCliente
                    };
                } else {
                    return new UsuarioData {
                        UserName = usuario.UserName,
                            Token = null,
                            Email = null,
                            NOMBRECOMPLETO = usuario.NOMBRECOMPLETO,
                            ImagenPerfil = null
                    };
                }
            }
        }
    }
}