using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class ComentariosTareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMENTARIOSDETAREAS",
                columns: table => new
                {
                    comentarioId = table.Column<Guid>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    FECGRA = table.Column<DateTime>(nullable: false),
                    TAREAId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMENTARIOSDETAREAS", x => x.comentarioId);
                    table.ForeignKey(
                        name: "FK_COMENTARIOSDETAREAS_TAREAS_TAREAId",
                        column: x => x.TAREAId,
                        principalTable: "TAREAS",
                        principalColumn: "TAREA_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOSDETAREAS_TAREAId",
                table: "COMENTARIOSDETAREAS",
                column: "TAREAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMENTARIOSDETAREAS");
        }
    }
}
