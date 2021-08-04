using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class NOTAS {
        [Key]
        public Guid NOTA_Id { get; set; }
        public string RemitenteUserName {get;set;}
        public string DestinatarioUserName {get;set;}
        public string Texto {get;set;}
        public DateTime FECGRA { get; set; }
        public string DIFUSION {get;set;}
        public string ArchivoUrl {get;set;}
        public DateTime? LEIDO {get;set;}  
    }
}