using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia {
    public class CRMContext : IdentityDbContext<Usuarios, Roles, string> {
        public CRMContext (DbContextOptions<CRMContext> options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<V_LEIDO_POR> (v => {
                v.HasNoKey ();
                v.ToView ("V_LEIDO_POR");
                v.Property (v => v.DIFUSION_ID).HasColumnType ("DIFUSION_ID");
                v.Property (v => v.LEIDOPOR).HasColumnType ("LEIDOPOR");
                v.Property (v => v.NOTA_ID).HasColumnType ("NOTA_ID");
                v.Property (v => v.FECHALEIDA).HasColumnType ("FECHALEIDA");
            });
                modelBuilder.Entity<V_ARCHIVOS_CLIENTES> (v => {
                v.HasNoKey ();
                v.ToView ("V_ARCHIVOS_CLIENTES");
                v.Property (v => v.NombreArchivo).HasColumnType ("NombreArchivo");
                v.Property (v => v.fechaarchivo).HasColumnType ("fechaarchivo");
    
            });
                 modelBuilder.Entity<V_ARCHIVOS_POSIBLESCLIENTES> (v => {
                v.HasNoKey ();
                v.ToView ("V_ARCHIVOS_POSIBLESCLIENTES");
                v.Property (v => v.NombreArchivo).HasColumnType ("NombreArchivo");
                v.Property (v => v.fechaarchivo).HasColumnType ("fechaarchivo");
    
            });
              modelBuilder.Entity<GRAFICO_TAREAS> (v => {
                v.HasNoKey ();
                v.ToView ("GRAFICO_TAREAS");
                v.Property (v => v.usuario).HasColumnType ("usuario");
                v.Property (v => v.tareas_pendientes_global).HasColumnType ("tareas_pendientes_global");
                v.Property (v => v.tareas_cerradas_global).HasColumnType ("tareas_cerradas_global");
                v.Property (v => v.tareas_pendientes_dia).HasColumnType ("tareas_pendientes_dia");
                v.Property (v => v.tareas_cerradas_dia).HasColumnType ("tareas_cerradas_dia");

            });
             modelBuilder.Entity<GRAFICO_CAMPANAS> (v => {
                v.HasNoKey ();
                v.ToView ("GRAFICO_CAMPANAS");
                v.Property (v => v.CAMPANA).HasColumnType ("CAMPANA");
                v.Property (v => v.CLIENTES).HasColumnType ("CLIENTES");
            });


            modelBuilder.Entity<ROLES_PANTALLAS> ()
                .HasKey (o => new { o.PANTALLAId, o.RoleId });
            base.OnModelCreating (modelBuilder);
        }

        public DbSet<CAMPANAS> CAMPANAS { get; set; }
        public DbSet<Dominio.CLIENTES> CLIENTES { get; set; }
        public DbSet<CONTACTOS> CONTACTOS { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<NOTAS> NOTAS { get; set; }
        public DbSet<POSIBLESCLIENTES> POSIBLESCLIENTES { get; set; }
        public DbSet<TAREAS> TAREAS { get; set; }
        public DbSet<TIPOSCAMPANAS> TIPOSCAMPANAS { get; set; }
        public DbSet<TIPOSTAREAS> TIPOSTAREAS { get; set; }
        public DbSet<BARRIOS> BARRIOS { get; set; }
        public DbSet<CIUDADES> CIUDADES { get; set; }
        public DbSet<TELEFONOS> TELEFONOS { get; set; }
        public DbSet<DIRECCIONES> DIRECCIONES { get; set; }
        public DbSet<TELEFONOSTAREAS> TELEFONOSTAREAS { get; set; }
        public DbSet<DIRECCIONESTAREAS> DIRECCIONESTAREAS { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<REDES_CLIENTES> REDES_CLIENTES { get; set; }
        public DbSet<DIFUSIONESLEIDAS> DIFUSIONESLEIDAS { get; set; }
        public DbSet<V_LEIDO_POR> V_LEIDO_POR { get; set; }
        public DbSet<PANTALLAS> PANTALLAS { get; set; }
        public DbSet<ROLES_PANTALLAS> ROLES_PANTALLAS { get; set; }
        public DbSet<Categoria> CATEGORIA { get; set; }
        public DbSet<Subcategoria> SUBCATEGORIA { get; set; }
        public DbSet<SUGERENCIAS> SUGERENCIAS { get; set; }
        public DbSet<AUDITORIA> AUDITORIA { get; set; }
        public DbSet<ALERTAS> ALERTAS { get; set; }
        public DbSet<V_ARCHIVOS_CLIENTES> V_ARCHIVOS_CLIENTES {get;set;}
        public DbSet<V_ARCHIVOS_POSIBLESCLIENTES> V_ARCHIVOS_POSIBLESCLIENTES {get;set;}

        public DbSet <COMENTARIOSDETAREAS> COMENTARIOSDETAREAS {get;set;}
        public DbSet <GRAFICO_TAREAS> GRAFICO_TAREAS {get;set;}

        public DbSet <GRAFICO_CAMPANAS> GRAFICO_CAMPANAS {get;set;}

    }
}