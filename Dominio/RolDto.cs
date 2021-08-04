using System.Collections.Generic;

namespace Aplicacion.Seguridad
{
    public class RolDto
    {
        public string Id{set;get;}

        public string DESCRIPCIONROL{set;get;}

        public ICollection<PantallaDto> ListaPantallasRol{set;get;}
    }
}