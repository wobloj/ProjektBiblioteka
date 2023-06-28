using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBiblioteka.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_BookIdId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_People_PersonIdId",
                table: "Borrow");

            migrationBuilder.RenameColumn(
                name: "PersonIdId",
                table: "Borrow",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "BookIdId",
                table: "Borrow",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_PersonIdId",
                table: "Borrow",
                newName: "IX_Borrow_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_BookIdId",
                table: "Borrow",
                newName: "IX_Borrow_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_People_PersonId",
                table: "Borrow",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_People_PersonId",
                table: "Borrow");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Borrow",
                newName: "PersonIdId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Borrow",
                newName: "BookIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_PersonId",
                table: "Borrow",
                newName: "IX_Borrow_PersonIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_BookId",
                table: "Borrow",
                newName: "IX_Borrow_BookIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_BookIdId",
                table: "Borrow",
                column: "BookIdId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_People_PersonIdId",
                table: "Borrow",
                column: "PersonIdId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
