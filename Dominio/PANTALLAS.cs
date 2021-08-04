using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class PANTALLAS {

        [Key]
        public Guid PANTALLA_Id { get; set; }

        public string PATH { get; set; }
        public string NOMBREPANTALLA { get; set; }
        public ICollection<ROLES_PANTALLAS> RolesLista { get; set; }
        public Subcategoria Subcategoria{set;get;}

    }
}