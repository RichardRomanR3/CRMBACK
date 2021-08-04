using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio {

    public class CAMPANAS {
        [Key]
        public Guid CAMPANA_Id { get; set; }
        public int CODCAMPANA { get; set; }
        public string NUMCAMPANA { get; set; }
        public string DESCRICAMPANA { get; set; }
        public string ESTADOCAMPANA { get; set; }
        public string OBJETIVOS {get;set;}
        [Column (TypeName = "decimal(18,4)")]
        public decimal PRESUPUESTO {get;set;}
        public string GEOGRAFIA {get;set;}
        public string EMPRESACONTRATADA {get;set;}

        public DateTime FECGRA { get; set; }
        public ICollection<CLIENTES> ClientesLista { get; set; }
        public TIPOSCAMPANAS TIPOSCAMPANAS { get; set; }
        
    }
}