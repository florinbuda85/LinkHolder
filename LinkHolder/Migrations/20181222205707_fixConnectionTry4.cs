using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkHolder.Migrations
{
    public partial class fixConnectionTry4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LinkTag",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTag", x => new { x.LinkId, x.TagId });
                    table.ForeignKey(
                        name: "FK_LinkTag_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkTag_TagId",
                table: "LinkTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTag");

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
    }
}
