using System;
using System.Collections.Generic;

namespace Dominio
{
    public class CategoriaDto
    {
        public Guid CategoriaId{set;get;}
        public string ruta{set;get;}
        public string nombre{set;get;}
        public ICollection<SubcategoriaDto> SubcategoriasLista{set;get;}
    }
}