using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExpenseControl.WebApi.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampsToAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "transaction",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "transaction",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "person",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "person",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "category",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "category",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "person");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "person");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "category");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "category");
        }
    }
}
