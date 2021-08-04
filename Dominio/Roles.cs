using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dominio
{
    public class Roles : IdentityRole<string>
    {
        public string DESCRIPCIONROL {get;set;}
        public ICollection<ROLES_PANTALLAS> PantallasLista { get; set; }
    }
}