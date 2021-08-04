using System;
using Aplicacion.ACCIONNOTAS;
using Dominio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace crmbackend {
    public class Program {
        public static void Main (string[] args) {
            var hostserver = CreateHostBuilder (args).Build ();
            var hubContext = hostserver.Services.GetService (typeof (IHubContext<ChatHub>));
            using (var ambiente = hostserver.Services.CreateScope ()) {
                var services = ambiente.ServiceProvider;
                try {
                    var userManager = services.GetRequiredService<UserManager<Usuarios>> ();
                    var roleManager = services.GetRequiredService<RoleManager<Roles>> ();
                    var context = services.GetRequiredService<CRMContext> ();
                    context.Database.Migrate ();
                    DataPrueba.InsertarData (context, userManager).Wait ();
                } catch (Exception e) {

                    var logging = services.GetRequiredService<ILogger<Program>> ();
                    logging.LogError (e, "OCURRIO UN ERROR EN LA MIGRACION");
                }

            }
            hostserver.Run ();

        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}