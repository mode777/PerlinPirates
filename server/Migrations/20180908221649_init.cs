using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity",
                columns: table => new
                {
                    ChunkX = table.Column<int>(nullable: false),
                    ChunkY = table.Column<int>(nullable: false),
                    X = table.Column<byte>(nullable: false),
                    Y = table.Column<byte>(nullable: false),
                    EntityId = table.Column<short>(nullable: false),
                    Payload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity", x => new { x.ChunkX, x.ChunkY, x.X, x.Y });
                });

            migrationBuilder.CreateIndex(
                name: "IX_entity_ChunkX_ChunkY",
                table: "entity",
                columns: new[] { "ChunkX", "ChunkY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entity");
        }
    }
}
