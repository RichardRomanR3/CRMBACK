using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class CLIENTES {
        [Key]
        public Guid CLIENTE_Id { get; set; }
        public int CODCLIENTE { get; set; }
        public string NUMCLIENTE { get; set; }
        public string NOMBRE { get; set; }

        public string APELLIDO { get; set; }

        public string CI { get; set; }
        public string RUC { get; set; }
        public int? ESTADOCLIENTE {get;set;}
        public string PROFESIONORUBRO{get;set;}
        public string HOBBY{get;set;}
        public string OBSERVACIONES {get;set;}
        public DateTime FECGRA { get; set; }
        public DateTime? FECHULTMOD { get; set; }
        public DateTime? ENTROCOMOPC { get; set; }
        public string NombreArchivo {get;set;}

        public CAMPANAS CAMPANAS { get; set; }
     
        public ICollection<CONTACTOS> ContactosLista { get; set; }
        public ICollection<TAREAS> TareasLista { get; set; }
        public ICollection<TELEFONOS> TelefonosLista { get; set; }
        public ICollection<DIRECCIONES> DireccionesLista { get; set; }
        public ICollection<REDES_CLIENTES> RedesLista {get;set;}
        public ICollection<SUGERENCIAS> SugerenciasLista {get;set;}
    }
}