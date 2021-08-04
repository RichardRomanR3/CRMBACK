using System;

namespace Dominio
{
    public class SUGERENCIASDto
    {
        public Guid Id {get;set;}
        public string sugerencia {get;set;}
         public string estado {get;set;}
        public DateTime FECGRA {get;set;}
        public CLIENTESDto Cliente {get;set;}
    }
}