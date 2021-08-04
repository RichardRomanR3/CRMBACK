using System.Collections.Generic;

namespace Aplicacion.Seguridad {
    public class UsuarioData {
        public string Id{get;set;}
        public string NOMBRECOMPLETO { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Confirmarpassword { get; set; }
        public string NUMEROTELEFONO { get; set; }
        public List<string> RolesUsuario {get;set;}
        public RolDto PantallasUsuario {get;set;}

        public ImagenGeneral ImagenPerfil { get; set; }
    }
}