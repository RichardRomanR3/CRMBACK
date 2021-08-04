using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class TIPOSTAREAS {
        [Key]
        public Guid TIPOTAREA_Id { get; set; }

        public int CODTIPOTAREA { get; set; }
        public string NUMTIPOTAREA { get; set; }

        public string DESCRITIPOTAREA { get; set; }
        public DateTime FECGRA { get; set; }
        public ICollection<TAREAS> TareasLista { get; set; }

    }
}