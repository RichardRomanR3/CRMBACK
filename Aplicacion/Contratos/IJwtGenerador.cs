using System.Collections.Generic;
using Dominio;

namespace Aplicacion.Contratos {
    public interface IJwtGenerador {
        string CrearToken (Usuarios usuario, List<string> roles);
    }
}