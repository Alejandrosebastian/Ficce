using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FICCE.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Tipoempresa",
                maxLength: 220,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Estantes",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Estantes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Tipoempresa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 220);
        }
    }
}
