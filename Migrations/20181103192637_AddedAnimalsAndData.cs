using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SafariApi.Migrations
{
    public partial class AddedAnimalsAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeenAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Species = table.Column<string>(nullable: true),
                    CountOfTimesSeen = table.Column<int>(nullable: false),
                    LocationOfLastSeen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeenAnimals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SeenAnimals",
                columns: new[] { "Id", "CountOfTimesSeen", "LocationOfLastSeen", "Species" },
                values: new object[,]
                {
                    { -1, 1, "Field", "Lion" },
                    { -2, 8, "Field", "Zebra" },
                    { -3, 7, "Lake", "Elephant" },
                    { -4, 42, "Cavern", "Hyena" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeenAnimals");
        }
    }
}
