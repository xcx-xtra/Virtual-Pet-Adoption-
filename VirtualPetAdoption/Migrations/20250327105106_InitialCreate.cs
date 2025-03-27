using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VirtualPetAdoption.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Playfulness = table.Column<int>(type: "INTEGER", nullable: false),
                    Affection = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PreferredPlayfulness = table.Column<int>(type: "INTEGER", nullable: false),
                    PreferredAffection = table.Column<int>(type: "INTEGER", nullable: false),
                    AdoptedPetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Pets_AdoptedPetId",
                        column: x => x.AdoptedPetId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Affection", "Description", "ImageUrl", "Name", "Playfulness", "Species" },
                values: new object[,]
                {
                    { 1, 5, "A playful and affectionate cat.", "/images/cat.png", "Fluffy", 4, "Cat" },
                    { 2, 4, "An energetic dog who loves to play.", "/images/dog.png", "Rex", 5, "Dog" },
                    { 3, 3, "A quiet and independent cat.", "/images/cat2.png", "Whiskers", 2, "Cat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdoptedPetId",
                table: "Users",
                column: "AdoptedPetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
