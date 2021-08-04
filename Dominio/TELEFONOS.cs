using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class TELEFONOS {
        [Key]
        public Guid TELEFONO_Id { get; set; }
        public string CODTELEFONO {get;set;}
        public string DESCRITELEFONO { get; set; }
        public string DETALLESTELEFONO { get; set; }
        public string CONTESTA {get;set;}
        public CLIENTES CLIENTE { get; set; }

    }
}