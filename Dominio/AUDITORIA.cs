using System;

namespace Dominio
{
    public class AUDITORIA
    {
        public Guid Id {get;set;}

        public string usuarionombre {get;set;}
        public string accion {get;set;}
        public string panel {get;set;}
        public string tabla {get;set;}
        public string filaafectada {get;set;}
        public DateTime fechadeaccion {get;set;}
        public string UsuarioId {get;set;}
        public Usuarios Usuario {get;set;}
        
    }
}