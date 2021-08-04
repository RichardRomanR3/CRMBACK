using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class POSIBLESCLIENTESDto {
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string RUC { get; set; }
        public string CI { get; set; }
        public string TELEFONO { get; set; }
        public string DIRECCION { get; set; }
        public string EMAIL { get; set; }
        public string PROFESIONORUBRO{get;set;}
        public string HOBBY{get;set;}
        public string OBSERVACIONES {get;set;}
        public string USUARIOPC {get;set;}
        public DateTime FECGRA { get; set; }
        public DateTime? ULTIMOMOD {get;set;}
    }
}