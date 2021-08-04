using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class DIFUSIONESLEIDAS
    {
        [Key]
        public Guid DIFUSION_ID {get;set;}
        public string LEIDOPOR {get;set;}
        public DateTime FECHALEIDA {get;set;}
        public NOTAS NOTA {get;set;}
    }
}