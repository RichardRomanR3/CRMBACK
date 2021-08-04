using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId{set;get;}
        public string ruta{set;get;}
        public string nombre{set;get;}
        public ICollection<Subcategoria> SubcategoriasLista { get; set; }
    }
}