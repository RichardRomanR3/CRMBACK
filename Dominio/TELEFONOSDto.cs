using System;


namespace Dominio
{
    public class TELEFONOSDto
    {
        
        public Guid TELEFONO_Id { get; set; }
        public string DESCRITELEFONO { get; set; }
         public string DETALLESTELEFONO { get; set; }
         public int PRIORIDAD {get;set;}
        public CLIENTESTAREASDto CLIENTE { get; set; }
    }
}