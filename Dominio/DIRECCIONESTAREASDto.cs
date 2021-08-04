using System;
namespace Dominio
{
    public class DIRECCIONESTAREASDto
    {
    public Guid DIRECCION_Id {get;set;}
      public string DESCRIDIRECCION {get;set;}
       public string DETALLESDIRECCION { get; set; }
      public CIUDADESDto CIUDAD {get;set;}  
      public BARRIOSDto BARRIO {get;set;}
      public CLIENTESTAREASDto CLIENTE {get;set;}
      public TAREASDto TAREA {get;set;}
    }
}