using System;
using System.Collections.Generic;
namespace Dominio
{
    public class TAREASGENERALESDto
    {
        public Guid TAREA_Id { get; set; }
        public int CODTAREA { get; set; }
        public string NUMTAREA { get; set; }
        public string ASIGNADOPOR { get; set; }
        public string USUARIOASIGNADO { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAVTO { get; set; }
        public DateTime? ALARMA { get; set; }
        public DateTime? COMENZADO { get; set; }
        public DateTime? COMPLETADO { get; set; }
        public string NOTIFICADO {get;set;}
        public string MOTIVOCANCELACION {get;set;}
        public DateTime? TPOSIBLECOBRO {get;set;}
        public string COBROASIGNADO {get;set;}
     
        public TIPOSTAREASDto TIPOTAREA { get; set; }
        public CLIENTESTAREASDto CLIENTE { get; set; } 
        public string AsignadorId{get;set;}

        public POSIBLESCLIENTESDto POSIBLECLIENTE {get;set;}
    }
}