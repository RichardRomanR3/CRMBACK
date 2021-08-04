using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class DIRECCIONESTAREAS
    {
          [Key]
      public Guid DIRECCION_Id {get;set;}
      public string DESCRIDIRECCION {get;set;}
      public string DETALLESDIRECCION { get; set; }
      public string CODDIRECCION {get;set;}
       public string SE_ENCUENTRA {get;set;}
      public TAREAS TAREA{get;set;}
      public CLIENTES CLIENTE {get;set;}
      public CIUDADES CIUDAD {get;set;}  
      public BARRIOS BARRIO {get;set;}
    }
}