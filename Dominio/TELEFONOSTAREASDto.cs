using System;
namespace Dominio
{
    public class TELEFONOSTAREASDto
    {
         public Guid TELEFONOTAREA_Id { get; set; }
        public string DESCRITELEFONOTAREA { get; set; }
         public string DETALLESTELEFONOTAREA { get; set; }
        public CLIENTESTAREASDto CLIENTE { get; set; }
        public TAREASDto TAREA {get;set;}
    }
}