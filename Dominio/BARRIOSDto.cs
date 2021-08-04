using System;

namespace Dominio
{
    public class BARRIOSDto
    {
         public Guid BARRIO_Id { get; set; }
    
        public string DESCRIBARRIO { get; set; }
        public CIUDADESDto CIUDAD {get;set;}
    }
}