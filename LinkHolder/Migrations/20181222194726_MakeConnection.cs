using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkHolder.Migrations
{
    public partial class MakeConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "Tags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LinkId",
                table: "Tags",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Links_LinkId",
                table: "Tags",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Links_LinkId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_LinkId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Tags");
        }
    }
}
