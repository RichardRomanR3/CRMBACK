using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class CONTACTOS {
        [Key]
        public Guid CONTACTO_Id { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string USUARIOP{get;set;}
        public string OBSERVACIONES { get; set; }
        public DateTime FECGRA { get; set; }
        public DateTime? FECHULTMOD {get;set;}
        public CLIENTES CLIENTE { get; set; }
        public string UsuarioId {get;set;}
        public Usuarios Usuario {get;set;}
    }
}