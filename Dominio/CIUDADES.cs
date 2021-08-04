using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class CIUDADES {
        [Key]
        public Guid CIUDAD_Id { get; set; }

        public string DESCRICIUDAD { get; set; }
         public ICollection<BARRIOS> BarriosLista { get; set; }
    }
}