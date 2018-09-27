using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldServer.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorldEntity",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    ChunkX = table.Column<int>(nullable: false),
                    ChunkY = table.Column<int>(nullable: false),
                    X = table.Column<byte>(nullable: false),
                    Y = table.Column<byte>(nullable: false),
                    Json = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorldEntity_ChunkX_ChunkY",
                table: "WorldEntity",
                columns: new[] { "ChunkX", "ChunkY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorldEntity");
        }
    }
}
