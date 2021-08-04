using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class REDES_CLIENTES
    {
        [Key]
        public Guid RED_Id {get;set;}
        public string Nick {get;set;}
        
        public string RedSocial {get;set;}
        public CLIENTES CLIENTE {get;set;}
    }
}