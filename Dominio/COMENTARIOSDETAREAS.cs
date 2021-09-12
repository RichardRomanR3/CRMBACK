using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class COMENTARIOSDETAREAS
    {
        [Key]
        public Guid comentarioId {get;set;}
        public string comentario {get;set;}
        public DateTime FECGRA {get;set;}

        public Guid? TAREAId {get;set;}
        public TAREAS TAREA {get;set;}
    }
}