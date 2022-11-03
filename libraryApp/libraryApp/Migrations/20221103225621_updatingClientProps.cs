using Microsoft.EntityFrameworkCore.Migrations;

namespace libraryApp.Migrations
{
    public partial class updatingClientProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksCheckedOut",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumBooksCheckedOut",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "Books",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ClientId",
                table: "Books",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Clients_ClientId",
                table: "Books",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Clients_ClientId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ClientId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumBooksCheckedOut",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "BooksCheckedOut",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
