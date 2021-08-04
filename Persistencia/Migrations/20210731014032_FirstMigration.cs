using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DESCRIPCIONROL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NOMBRECOMPLETO = table.Column<string>(nullable: true),
                    NUMUSUARIO = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    NUMEROTELEFONO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(nullable: false),
                    ruta = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "CIUDADES",
                columns: table => new
                {
                    CIUDAD_Id = table.Column<Guid>(nullable: false),
                    DESCRICIUDAD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIUDADES", x => x.CIUDAD_Id);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    DocumentoId = table.Column<Guid>(nullable: false),
                    ObjetoReferencia = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Contenido = table.Column<byte[]>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.DocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nombrenormalizado = table.Column<string>(nullable: true),
                    razonsocial = table.Column<string>(nullable: true),
                    ruc = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    paginaweb = table.Column<string>(nullable: true),
                    nombrelogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTAS",
                columns: table => new
                {
                    NOTA_Id = table.Column<Guid>(nullable: false),
                    RemitenteUserName = table.Column<string>(nullable: true),
                    DestinatarioUserName = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    DIFUSION = table.Column<string>(nullable: true),
                    ArchivoUrl = table.Column<string>(nullable: true),
                    LEIDO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTAS", x => x.NOTA_Id);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSCAMPANAS",
                columns: table => new
                {
                    TIPOCAMPANA_Id = table.Column<Guid>(nullable: false),
                    CODTIPOCAMPANA = table.Column<int>(nullable: false),
                    NUMTIPOCAMPANA = table.Column<string>(nullable: true),
                    DESCRITIPOCAMPANA = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOSCAMPANAS", x => x.TIPOCAMPANA_Id);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSTAREAS",
                columns: table => new
                {
                    TIPOTAREA_Id = table.Column<Guid>(nullable: false),
                    CODTIPOTAREA = table.Column<int>(nullable: false),
                    NUMTIPOTAREA = table.Column<string>(nullable: true),
                    DESCRITIPOTAREA = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOSTAREAS", x => x.TIPOTAREA_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true),
                    minutosalerta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALERTAS_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUDITORIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    usuarionombre = table.Column<string>(nullable: true),
                    accion = table.Column<string>(nullable: true),
                    panel = table.Column<string>(nullable: true),
                    tabla = table.Column<string>(nullable: true),
                    filaafectada = table.Column<string>(nullable: true),
                    fechadeaccion = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDITORIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AUDITORIA_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POSIBLESCLIENTES",
                columns: table => new
                {
                    POSIBLECLIENTE_Id = table.Column<Guid>(nullable: false),
                    NOMBRE = table.Column<string>(nullable: true),
                    APELLIDO = table.Column<string>(nullable: true),
                    RUC = table.Column<string>(nullable: true),
                    CI = table.Column<string>(nullable: true),
                    TELEFONO = table.Column<string>(nullable: true),
                    DIRECCION = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    PROFESIONORUBRO = table.Column<string>(nullable: true),
                    HOBBY = table.Column<string>(nullable: true),
                    OBSERVACIONES = table.Column<string>(nullable: true),
                    USUARIOPC = table.Column<string>(nullable: true),
                    NombreArchivo = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    ULTIMOMOD = table.Column<DateTime>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSIBLESCLIENTES", x => x.POSIBLECLIENTE_Id);
                    table.ForeignKey(
                        name: "FK_POSIBLESCLIENTES_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUBCATEGORIA",
                columns: table => new
                {
                    SubcategoriaId = table.Column<Guid>(nullable: false),
                    ruta = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBCATEGORIA", x => x.SubcategoriaId);
                    table.ForeignKey(
                        name: "FK_SUBCATEGORIA_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CATEGORIA",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BARRIOS",
                columns: table => new
                {
                    BARRIO_Id = table.Column<Guid>(nullable: false),
                    DESCRIBARRIO = table.Column<string>(nullable: true),
                    CIUDAD_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARRIOS", x => x.BARRIO_Id);
                    table.ForeignKey(
                        name: "FK_BARRIOS_CIUDADES_CIUDAD_Id",
                        column: x => x.CIUDAD_Id,
                        principalTable: "CIUDADES",
                        principalColumn: "CIUDAD_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIFUSIONESLEIDAS",
                columns: table => new
                {
                    DIFUSION_ID = table.Column<Guid>(nullable: false),
                    LEIDOPOR = table.Column<string>(nullable: true),
                    FECHALEIDA = table.Column<DateTime>(nullable: false),
                    NOTA_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIFUSIONESLEIDAS", x => x.DIFUSION_ID);
                    table.ForeignKey(
                        name: "FK_DIFUSIONESLEIDAS_NOTAS_NOTA_Id",
                        column: x => x.NOTA_Id,
                        principalTable: "NOTAS",
                        principalColumn: "NOTA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAMPANAS",
                columns: table => new
                {
                    CAMPANA_Id = table.Column<Guid>(nullable: false),
                    CODCAMPANA = table.Column<int>(nullable: false),
                    NUMCAMPANA = table.Column<string>(nullable: true),
                    DESCRICAMPANA = table.Column<string>(nullable: true),
                    ESTADOCAMPANA = table.Column<string>(nullable: true),
                    OBJETIVOS = table.Column<string>(nullable: true),
                    PRESUPUESTO = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GEOGRAFIA = table.Column<string>(nullable: true),
                    EMPRESACONTRATADA = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    TIPOSCAMPANASTIPOCAMPANA_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAMPANAS", x => x.CAMPANA_Id);
                    table.ForeignKey(
                        name: "FK_CAMPANAS_TIPOSCAMPANAS_TIPOSCAMPANASTIPOCAMPANA_Id",
                        column: x => x.TIPOSCAMPANASTIPOCAMPANA_Id,
                        principalTable: "TIPOSCAMPANAS",
                        principalColumn: "TIPOCAMPANA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PANTALLAS",
                columns: table => new
                {
                    PANTALLA_Id = table.Column<Guid>(nullable: false),
                    PATH = table.Column<string>(nullable: true),
                    NOMBREPANTALLA = table.Column<string>(nullable: true),
                    SubcategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANTALLAS", x => x.PANTALLA_Id);
                    table.ForeignKey(
                        name: "FK_PANTALLAS_SUBCATEGORIA_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "SUBCATEGORIA",
                        principalColumn: "SubcategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    CLIENTE_Id = table.Column<Guid>(nullable: false),
                    CODCLIENTE = table.Column<int>(nullable: false),
                    NUMCLIENTE = table.Column<string>(nullable: true),
                    NOMBRE = table.Column<string>(nullable: true),
                    APELLIDO = table.Column<string>(nullable: true),
                    CI = table.Column<string>(nullable: true),
                    RUC = table.Column<string>(nullable: true),
                    ESTADOCLIENTE = table.Column<int>(nullable: true),
                    PROFESIONORUBRO = table.Column<string>(nullable: true),
                    HOBBY = table.Column<string>(nullable: true),
                    OBSERVACIONES = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    FECHULTMOD = table.Column<DateTime>(nullable: true),
                    ENTROCOMOPC = table.Column<DateTime>(nullable: true),
                    NombreArchivo = table.Column<string>(nullable: true),
                    CAMPANASCAMPANA_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.CLIENTE_Id);
                    table.ForeignKey(
                        name: "FK_CLIENTES_CAMPANAS_CAMPANASCAMPANA_Id",
                        column: x => x.CAMPANASCAMPANA_Id,
                        principalTable: "CAMPANAS",
                        principalColumn: "CAMPANA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROLES_PANTALLAS",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    PANTALLAId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES_PANTALLAS", x => new { x.PANTALLAId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ROLES_PANTALLAS_PANTALLAS_PANTALLAId",
                        column: x => x.PANTALLAId,
                        principalTable: "PANTALLAS",
                        principalColumn: "PANTALLA_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLES_PANTALLAS_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONTACTOS",
                columns: table => new
                {
                    CONTACTO_Id = table.Column<Guid>(nullable: false),
                    NOMBRE = table.Column<string>(nullable: true),
                    APELLIDO = table.Column<string>(nullable: true),
                    DIRECCION = table.Column<string>(nullable: true),
                    TELEFONO = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    USUARIOP = table.Column<string>(nullable: true),
                    OBSERVACIONES = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    FECHULTMOD = table.Column<DateTime>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACTOS", x => x.CONTACTO_Id);
                    table.ForeignKey(
                        name: "FK_CONTACTOS_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTACTOS_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIRECCIONES",
                columns: table => new
                {
                    DIRECCION_Id = table.Column<Guid>(nullable: false),
                    DESCRIDIRECCION = table.Column<string>(nullable: true),
                    DETALLESDIRECCION = table.Column<string>(nullable: true),
                    CODDIRECCION = table.Column<string>(nullable: true),
                    SE_ENCUENTRA = table.Column<string>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true),
                    CIUDAD_Id = table.Column<Guid>(nullable: true),
                    BARRIO_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIRECCIONES", x => x.DIRECCION_Id);
                    table.ForeignKey(
                        name: "FK_DIRECCIONES_BARRIOS_BARRIO_Id",
                        column: x => x.BARRIO_Id,
                        principalTable: "BARRIOS",
                        principalColumn: "BARRIO_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIRECCIONES_CIUDADES_CIUDAD_Id",
                        column: x => x.CIUDAD_Id,
                        principalTable: "CIUDADES",
                        principalColumn: "CIUDAD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIRECCIONES_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REDES_CLIENTES",
                columns: table => new
                {
                    RED_Id = table.Column<Guid>(nullable: false),
                    Nick = table.Column<string>(nullable: true),
                    RedSocial = table.Column<string>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REDES_CLIENTES", x => x.RED_Id);
                    table.ForeignKey(
                        name: "FK_REDES_CLIENTES_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUGERENCIAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    sugerencia = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUGERENCIAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUGERENCIAS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAREAS",
                columns: table => new
                {
                    TAREA_Id = table.Column<Guid>(nullable: false),
                    CODTAREA = table.Column<int>(nullable: false),
                    NUMTAREA = table.Column<string>(nullable: true),
                    ASIGNADOPOR = table.Column<string>(nullable: true),
                    USUARIOASIGNADO = table.Column<string>(nullable: true),
                    FECHACREACION = table.Column<DateTime>(nullable: false),
                    FECHAVTO = table.Column<DateTime>(nullable: false),
                    ALARMA = table.Column<DateTime>(nullable: true),
                    NOTIFICADO = table.Column<string>(nullable: true),
                    SINEMPEZAR = table.Column<DateTime>(nullable: true),
                    COMENZADO = table.Column<DateTime>(nullable: true),
                    COMPLETADO = table.Column<DateTime>(nullable: true),
                    CANCELADO = table.Column<DateTime>(nullable: true),
                    POSIBLECOBRO = table.Column<DateTime>(nullable: true),
                    COBROASIGNADO = table.Column<string>(nullable: true),
                    MOTIVOCANCELACION = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    TIPOSTAREASTIPOTAREA_Id = table.Column<Guid>(nullable: true),
                    CLIENTESCLIENTE_Id = table.Column<Guid>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true),
                    AsignadorId = table.Column<string>(nullable: true),
                    POSIBLECLIENTEId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAREAS", x => x.TAREA_Id);
                    table.ForeignKey(
                        name: "FK_TAREAS_CLIENTES_CLIENTESCLIENTE_Id",
                        column: x => x.CLIENTESCLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAREAS_POSIBLESCLIENTES_POSIBLECLIENTEId",
                        column: x => x.POSIBLECLIENTEId,
                        principalTable: "POSIBLESCLIENTES",
                        principalColumn: "POSIBLECLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAREAS_TIPOSTAREAS_TIPOSTAREASTIPOTAREA_Id",
                        column: x => x.TIPOSTAREASTIPOTAREA_Id,
                        principalTable: "TIPOSTAREAS",
                        principalColumn: "TIPOTAREA_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAREAS_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONOS",
                columns: table => new
                {
                    TELEFONO_Id = table.Column<Guid>(nullable: false),
                    CODTELEFONO = table.Column<string>(nullable: true),
                    DESCRITELEFONO = table.Column<string>(nullable: true),
                    DETALLESTELEFONO = table.Column<string>(nullable: true),
                    CONTESTA = table.Column<string>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONOS", x => x.TELEFONO_Id);
                    table.ForeignKey(
                        name: "FK_TELEFONOS_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIRECCIONESTAREAS",
                columns: table => new
                {
                    DIRECCION_Id = table.Column<Guid>(nullable: false),
                    DESCRIDIRECCION = table.Column<string>(nullable: true),
                    DETALLESDIRECCION = table.Column<string>(nullable: true),
                    CODDIRECCION = table.Column<string>(nullable: true),
                    SE_ENCUENTRA = table.Column<string>(nullable: true),
                    TAREA_Id = table.Column<Guid>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true),
                    CIUDAD_Id = table.Column<Guid>(nullable: true),
                    BARRIO_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIRECCIONESTAREAS", x => x.DIRECCION_Id);
                    table.ForeignKey(
                        name: "FK_DIRECCIONESTAREAS_BARRIOS_BARRIO_Id",
                        column: x => x.BARRIO_Id,
                        principalTable: "BARRIOS",
                        principalColumn: "BARRIO_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIRECCIONESTAREAS_CIUDADES_CIUDAD_Id",
                        column: x => x.CIUDAD_Id,
                        principalTable: "CIUDADES",
                        principalColumn: "CIUDAD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIRECCIONESTAREAS_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIRECCIONESTAREAS_TAREAS_TAREA_Id",
                        column: x => x.TAREA_Id,
                        principalTable: "TAREAS",
                        principalColumn: "TAREA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONOSTAREAS",
                columns: table => new
                {
                    TELEFONOTAREA_Id = table.Column<Guid>(nullable: false),
                    CODTELEFONOTAREA = table.Column<string>(nullable: true),
                    DESCRITELEFONOTAREA = table.Column<string>(nullable: true),
                    DETALLESTELEFONOTAREA = table.Column<string>(nullable: true),
                    CONTESTA = table.Column<string>(nullable: true),
                    CLIENTE_Id = table.Column<Guid>(nullable: true),
                    TAREA_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONOSTAREAS", x => x.TELEFONOTAREA_Id);
                    table.ForeignKey(
                        name: "FK_TELEFONOSTAREAS_CLIENTES_CLIENTE_Id",
                        column: x => x.CLIENTE_Id,
                        principalTable: "CLIENTES",
                        principalColumn: "CLIENTE_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TELEFONOSTAREAS_TAREAS_TAREA_Id",
                        column: x => x.TAREA_Id,
                        principalTable: "TAREAS",
                        principalColumn: "TAREA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTAS_UsuarioId",
                table: "ALERTAS",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AUDITORIA_UsuarioId",
                table: "AUDITORIA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_BARRIOS_CIUDAD_Id",
                table: "BARRIOS",
                column: "CIUDAD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CAMPANAS_TIPOSCAMPANASTIPOCAMPANA_Id",
                table: "CAMPANAS",
                column: "TIPOSCAMPANASTIPOCAMPANA_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_CAMPANASCAMPANA_Id",
                table: "CLIENTES",
                column: "CAMPANASCAMPANA_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACTOS_CLIENTE_Id",
                table: "CONTACTOS",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACTOS_UsuarioId",
                table: "CONTACTOS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DIFUSIONESLEIDAS_NOTA_Id",
                table: "DIFUSIONESLEIDAS",
                column: "NOTA_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_BARRIO_Id",
                table: "DIRECCIONES",
                column: "BARRIO_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_CIUDAD_Id",
                table: "DIRECCIONES",
                column: "CIUDAD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONES_CLIENTE_Id",
                table: "DIRECCIONES",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONESTAREAS_BARRIO_Id",
                table: "DIRECCIONESTAREAS",
                column: "BARRIO_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONESTAREAS_CIUDAD_Id",
                table: "DIRECCIONESTAREAS",
                column: "CIUDAD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONESTAREAS_CLIENTE_Id",
                table: "DIRECCIONESTAREAS",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DIRECCIONESTAREAS_TAREA_Id",
                table: "DIRECCIONESTAREAS",
                column: "TAREA_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PANTALLAS_SubcategoriaId",
                table: "PANTALLAS",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_POSIBLESCLIENTES_UsuarioId",
                table: "POSIBLESCLIENTES",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_REDES_CLIENTES_CLIENTE_Id",
                table: "REDES_CLIENTES",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_PANTALLAS_RoleId",
                table: "ROLES_PANTALLAS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SUBCATEGORIA_CategoriaId",
                table: "SUBCATEGORIA",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SUGERENCIAS_ClienteId",
                table: "SUGERENCIAS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_CLIENTESCLIENTE_Id",
                table: "TAREAS",
                column: "CLIENTESCLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_POSIBLECLIENTEId",
                table: "TAREAS",
                column: "POSIBLECLIENTEId");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_TIPOSTAREASTIPOTAREA_Id",
                table: "TAREAS",
                column: "TIPOSTAREASTIPOTAREA_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TAREAS_UsuarioId",
                table: "TAREAS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOS_CLIENTE_Id",
                table: "TELEFONOS",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOSTAREAS_CLIENTE_Id",
                table: "TELEFONOSTAREAS",
                column: "CLIENTE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONOSTAREAS_TAREA_Id",
                table: "TELEFONOSTAREAS",
                column: "TAREA_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTAS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AUDITORIA");

            migrationBuilder.DropTable(
                name: "CONTACTOS");

            migrationBuilder.DropTable(
                name: "DIFUSIONESLEIDAS");

            migrationBuilder.DropTable(
                name: "DIRECCIONES");

            migrationBuilder.DropTable(
                name: "DIRECCIONESTAREAS");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "REDES_CLIENTES");

            migrationBuilder.DropTable(
                name: "ROLES_PANTALLAS");

            migrationBuilder.DropTable(
                name: "SUGERENCIAS");

            migrationBuilder.DropTable(
                name: "TELEFONOS");

            migrationBuilder.DropTable(
                name: "TELEFONOSTAREAS");

            migrationBuilder.DropTable(
                name: "NOTAS");

            migrationBuilder.DropTable(
                name: "BARRIOS");

            migrationBuilder.DropTable(
                name: "PANTALLAS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TAREAS");

            migrationBuilder.DropTable(
                name: "CIUDADES");

            migrationBuilder.DropTable(
                name: "SUBCATEGORIA");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "POSIBLESCLIENTES");

            migrationBuilder.DropTable(
                name: "TIPOSTAREAS");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "CAMPANAS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TIPOSCAMPANAS");
        }
    }
}
