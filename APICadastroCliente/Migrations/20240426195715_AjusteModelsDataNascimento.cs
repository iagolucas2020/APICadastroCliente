using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICadastroCliente.Migrations
{
    public partial class AjusteModelsDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime(6)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Clientes",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 8)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
