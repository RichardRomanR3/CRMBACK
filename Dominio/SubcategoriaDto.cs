using System;
using System.Collections.Generic;
using Aplicacion.Seguridad;

namespace Dominio
{
    public class SubcategoriaDto
    {
        public Guid SubcategoriaId {set;get;}
        public string ruta{set;get;}
        public string nombre{set;get;}
        public ICollection<PantallaDto> PantallasLista { get; set; }
    }
}