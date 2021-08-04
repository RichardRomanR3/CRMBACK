using System;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(CRMContext context, UserManager<Usuarios> usuarioManager)
        {
            if(!usuarioManager.Users.Any())
            {
                var usuario = new Usuarios{Id = Guid.NewGuid().ToString(),NOMBRECOMPLETO = "ADMIN", UserName="Tileria",Email="tileria@tileria.com.py"};
                await usuarioManager.CreateAsync(usuario,"Tileria/2020");
            }
        }
    }
}