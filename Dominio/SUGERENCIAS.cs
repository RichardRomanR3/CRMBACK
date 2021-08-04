using System;

namespace Dominio
{
    public class SUGERENCIAS
    {
        public Guid Id {get;set;}
        public string sugerencia {get;set;}
        public string estado {get;set;}
        public DateTime FECGRA {get;set;}
        public Guid? ClienteId {get;set;}
        public CLIENTES Cliente {get;set;}
    }
}