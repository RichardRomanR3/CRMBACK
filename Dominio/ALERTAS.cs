using System;

namespace Dominio
{
    public class ALERTAS
    {
        public Guid Id {get;set;}
        public string UsuarioId {get;set;}
        public Usuarios Usuario {get;set;}
        public int minutosalerta {get;set;}
    }
}