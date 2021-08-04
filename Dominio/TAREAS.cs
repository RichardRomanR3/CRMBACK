using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio {
    public class TAREAS {
        [Key]
        public Guid TAREA_Id { get; set; }
        public int CODTAREA { get; set; }
        public string NUMTAREA { get; set; }
        public string ASIGNADOPOR { get; set; }
        public string USUARIOASIGNADO { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAVTO { get; set; }
        public DateTime? ALARMA { get; set; }
        public string NOTIFICADO { get; set; }
        public DateTime? SINEMPEZAR { get; set; }
        public DateTime? COMENZADO { get; set; }
        public DateTime? COMPLETADO { get; set; }
        public DateTime? CANCELADO { get; set; }
        public DateTime? POSIBLECOBRO {get;set;}
        public string COBROASIGNADO {get;set;}
        public string MOTIVOCANCELACION { get; set; }
        public DateTime FECGRA { get; set; }
        public TIPOSTAREAS TIPOSTAREAS { get; set; }
        public CLIENTES CLIENTES { get; set; }

        public string UsuarioId {get;set;}
        public Usuarios Usuario {get;set;}

        public string AsignadorId{get;set;}

        public Guid? POSIBLECLIENTEId {get;set;}
        public POSIBLESCLIENTES POSIBLECLIENTE {get;set;}
    }
}