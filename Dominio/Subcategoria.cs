using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Subcategoria
    {
        [Key]
        public Guid SubcategoriaId {set;get;}
        public string ruta{set;get;}
        public string nombre{set;get;}
        public Categoria Categoria{set;get;}
        public ICollection<PANTALLAS> PantallasLista { get; set; }
    }
}