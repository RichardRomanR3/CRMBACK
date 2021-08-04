using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class POSIBLESCLIENTES {
        [Key]
        public Guid POSIBLECLIENTE_Id { get; set; }
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
        public string NombreArchivo {get;set;}
        public DateTime FECGRA { get; set; }
        public DateTime? ULTIMOMOD {get;set;}

        public string UsuarioId {get;set;}
        public Usuarios Usuario {get;set;}
        public ICollection<TAREAS> TareasListaPC { get; set; }
    }
}