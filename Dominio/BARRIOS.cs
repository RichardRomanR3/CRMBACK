using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class BARRIOS
    {
        [Key]
        public Guid BARRIO_Id { get; set; }
    
        public string DESCRIBARRIO { get; set; }
        
        public CIUDADES CIUDAD { get; set; }
    }
}