using System;
using System.Text;
using Aplicacion.ACCIONARCHIVOS;
using Aplicacion.ACCIONCAMPANAS;
using Aplicacion.ACCIONEXCEL;
using Aplicacion.ACCIONNOTAS;
using Aplicacion.ACCIONREPORTES;
using Aplicacion.ACCIONTAREAS;
using Aplicacion.Contratos;
using Aplicacion.Seguridad;
using AutoMapper;
using crmbackend.Email;
using crmbackend.WhatsApp;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistencia;
using Seguridad;

namespace crmbackend {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (o => o.AddPolicy ("corsApp", builder => {
                    builder
                        .SetIsOriginAllowed (origin => true)
                        .AllowAnyMethod ()
                        .AllowAnyHeader ()
                        .AllowCredentials ();
                })

            );

            services.AddDbContext<CRMContext> (opt => { opt.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")); });           
            services.AddMediatR (typeof (ConsultaCampanas.Manejador).Assembly);
            services.AddScoped (typeof (ListarUsuarioPorRol.Manejador));


            services.AddControllers (opt => {
                var policy = new AuthorizationPolicyBuilder ().RequireAuthenticatedUser ().Build ();
                opt.Filters.Add (new AuthorizeFilter (policy));
            });

            var builder = services.AddIdentityCore<Usuarios> ();
            var identityBuilder = new IdentityBuilder (builder.UserType, builder.Services);
            identityBuilder.AddRoles<Roles> ();
            identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Usuarios>> ();
            identityBuilder.AddEntityFrameworkStores<CRMContext> ();
            identityBuilder.AddSignInManager<SignInManager<Usuarios>> ();
            services.TryAddSingleton<ISystemClock, SystemClock> ();
            services.AddScoped<IJwtGenerador, JwtGenerador> ();

            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("Tileria palabra secreta"));

            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme).AddJwtBearer (opt => {
                opt.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateAudience = false,
                ValidateIssuer = false
                };
            });

            services.AddSingleton<ISubirArchivos, SubirArchivos> ();
            services.AddSingleton<IExcel, ExcelToList> ();
            services.AddSingleton<ISenderWhatsapp, SenderWhatsAppService> ();
            services.AddScoped<IUsuarioSesion, UsuarioSesion> ();
            services.AddAutoMapper (typeof (ConsultaTareaGeneral.Manejador));
            services.Configure<SmtpSettings> (Configuration.GetSection ("SmtpSettings"));
            services.AddSingleton<IEmailSenderService, EmailSenderService> ();
            services.AddSignalR ().AddHubOptions<ChatHub> (options => {
                options.EnableDetailedErrors = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseStaticFiles (new StaticFileOptions {
                ServeUnknownFileTypes = true, //allow unkown file types also to be served
            });
            app.UseCors ("corsApp");
            app.UseDefaultFiles ();
            app.UseStaticFiles ();
            //app.UseHttpsRedirection();
            app.UseAuthentication ();
            app.UseRouting ();
            app.UseAuthorization ();
            app.UseEndpoints (endpoints => {
                endpoints.MapHub<ChatHub> ("/chatHub", options => {
                    options.Transports =
                        HttpTransportType.WebSockets |
                        HttpTransportType.LongPolling;
                });
                endpoints.MapControllers ();
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{actions=Index}/{id?}"
                );
                endpoints.MapFallbackToController ("Index", "Home");
            });

        }
    }
}