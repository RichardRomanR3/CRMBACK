using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class TELEFONOSTAREAS
    {
         [Key]
        public Guid TELEFONOTAREA_Id { get; set; }
        public string CODTELEFONOTAREA {get;set;}
        public string DESCRITELEFONOTAREA { get; set; }
        public string DETALLESTELEFONOTAREA { get; set; }
        public string CONTESTA {get;set;}
         public CLIENTES CLIENTE { get; set; }
         public TAREAS TAREA {get;set;}
    }
}