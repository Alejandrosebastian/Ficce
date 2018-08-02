using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FICCE.Migrations
{
    public partial class ciudad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "año",
                table: "Evento");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Evento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imagen",
                table: "Compra",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Compra");

            migrationBuilder.AddColumn<DateTime>(
                name: "año",
                table: "Evento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
