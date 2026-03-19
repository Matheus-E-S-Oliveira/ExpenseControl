using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseControl.WebApi.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_category_CategoryId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_person_PersonId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CatgoryId",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "transaction");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "transaction",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "transaction",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_PersonId",
                table: "transaction",
                newName: "IX_transaction_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_CategoryId",
                table: "transaction",
                newName: "IX_transaction_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "transaction",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "transaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_category_CategoryId",
                table: "transaction",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_person_PersonId",
                table: "transaction",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_category_CategoryId",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_person_PersonId",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");

            migrationBuilder.RenameTable(
                name: "transaction",
                newName: "Transaction");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Transaction",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Transaction",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_PersonId",
                table: "Transaction",
                newName: "IX_Transaction_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_CategoryId",
                table: "Transaction",
                newName: "IX_Transaction_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Transaction",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Transaction",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<Guid>(
                name: "CatgoryId",
                table: "Transaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_person_PersonId",
                table: "Transaction",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
