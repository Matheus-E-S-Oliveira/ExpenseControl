using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseControl.WebApi.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "category",
                newName: "purpose");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "category",
                newName: "description");

            migrationBuilder.AlterColumn<int>(
                name: "purpose",
                table: "category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "category",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_category_CategoryId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "purpose",
                table: "Category",
                newName: "Purpose");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Category",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "Purpose",
                table: "Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
