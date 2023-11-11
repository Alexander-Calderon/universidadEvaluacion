using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_escolar",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    anio_inicio = table.Column<int>(type: "int", nullable: false),
                    anio_fin = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_curso);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    nombre_departamento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_departamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    id_grado = table.Column<int>(type: "int", nullable: false),
                    nombre_grado = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_grado);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    dni = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    genero = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_persona = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_persona);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    id_profesor = table.Column<int>(type: "int", nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_profesor);
                    table.ForeignKey(
                        name: "profesor_ibfk_1",
                        column: x => x.id_profesor,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                    table.ForeignKey(
                        name: "profesor_ibfk_2",
                        column: x => x.id_departamento,
                        principalTable: "departamento",
                        principalColumn: "id_departamento");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id_asignatura = table.Column<int>(type: "int", nullable: false),
                    nombre_asignatura = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creditos = table.Column<float>(type: "float", nullable: true),
                    tipo_asignatura = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_grado = table.Column<int>(type: "int", nullable: true),
                    curso = table.Column<int>(type: "int", nullable: true),
                    id_departamento = table.Column<int>(type: "int", nullable: true),
                    id_profesor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_asignatura);
                    table.ForeignKey(
                        name: "asignatura_ibfk_1",
                        column: x => x.id_grado,
                        principalTable: "grado",
                        principalColumn: "id_grado");
                    table.ForeignKey(
                        name: "asignatura_ibfk_2",
                        column: x => x.id_departamento,
                        principalTable: "departamento",
                        principalColumn: "id_departamento");
                    table.ForeignKey(
                        name: "asignatura_ibfk_3",
                        column: x => x.id_profesor,
                        principalTable: "profesor",
                        principalColumn: "id_profesor");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "alumno_se_matricula_asignatura",
                columns: table => new
                {
                    id_alumno = table.Column<int>(type: "int", nullable: false),
                    id_asignatura = table.Column<int>(type: "int", nullable: false),
                    id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_alumno, x.id_asignatura, x.id_curso });
                    table.ForeignKey(
                        name: "alumnosematriculaasignaturas_ibfk_1",
                        column: x => x.id_alumno,
                        principalTable: "persona",
                        principalColumn: "id_persona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "alumnosematriculaasignaturas_ibfk_2",
                        column: x => x.id_asignatura,
                        principalTable: "asignatura",
                        principalColumn: "id_asignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "alumnosematriculaasignaturas_ibfk_3",
                        column: x => x.id_curso,
                        principalTable: "curso_escolar",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_alumno_se_matricula_asignatura_id_asignatura",
                table: "alumno_se_matricula_asignatura",
                column: "id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_alumno_se_matricula_asignatura_id_curso",
                table: "alumno_se_matricula_asignatura",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "id_departamento",
                table: "asignatura",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "id_grado",
                table: "asignatura",
                column: "id_grado");

            migrationBuilder.CreateIndex(
                name: "id_profesor",
                table: "asignatura",
                column: "id_profesor");

            migrationBuilder.CreateIndex(
                name: "id_departamento1",
                table: "profesor",
                column: "id_departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumno_se_matricula_asignatura");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "curso_escolar");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "departamento");
        }
    }
}
