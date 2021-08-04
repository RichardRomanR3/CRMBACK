using System;

namespace Dominio
{
    public class TAREASDto
    {
        public Guid TAREA_Id { get; set; }
        public int CODTAREA { get; set; }
        public string NUMTAREA { get; set; }
        public string ASIGNADOPOR { get; set; }
        public string USUARIOASIGNADO { get; set; }
        public DateTime FECHACREACION { get; set; }
        public DateTime FECHAVTO { get; set; }
        public DateTime? COMENZADO { get; set; }
        public DateTime? COMPLETADO { get; set; }
        public DateTime? TPOSIBLECOBRO {get;set;}
        public string MOTIVOCANCELACION {get;set;}
        public UsuarioDto Usuario {get;set;}
        public string AsignadorId{get;set;}
    }
}