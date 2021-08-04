using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class TIPOSCAMPANAS {
        [Key]
        public Guid TIPOCAMPANA_Id { get; set; }

        public int CODTIPOCAMPANA { get; set; }
        public string NUMTIPOCAMPANA { get; set; }
        public string DESCRITIPOCAMPANA { get; set; }
        public DateTime FECGRA { get; set; }
        public ICollection<CAMPANAS> CampanasLista { get; set; }
    }
}