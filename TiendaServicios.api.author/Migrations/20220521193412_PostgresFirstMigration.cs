using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.api.author.Migrations
{
    public partial class PostgresFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AuthorGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    GradoAcademicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AcademicCenter = table.Column<string>(type: "text", nullable: true),
                    DateGrade = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    AcademyGradeGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => x.GradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_AcademicDegree_BookAuthor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "BookAuthor",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDegree_AuthorId",
                table: "AcademicDegree",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "BookAuthor");
        }
    }
}
