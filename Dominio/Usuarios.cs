using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dominio {
    public class Usuarios : IdentityUser<string> {
        public string NOMBRECOMPLETO { get; set; }
        public string NUMUSUARIO {get;set;}
        public DateTime FECGRA { get; set; }
        public string NUMEROTELEFONO {get;set;}
        public ICollection<TAREAS> TareasLista {get;set;}
       
        public ICollection<CONTACTOS> ContactosLista {get;set;}
        public ICollection<POSIBLESCLIENTES> PosiblesClientesLista {get;set;}
        public ICollection<AUDITORIA> ListaAudi {get;set;}
        public ALERTAS HoraDeAlerta {get;set;}
      
    }
}