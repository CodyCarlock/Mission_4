using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission_4.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_To = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoriesCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Action/Adventure" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Family" },
                    { 5, "Horror/Suspense" },
                    { 6, "Miscellaneous" },
                    { 7, "Romance" },
                    { 8, "Television" },
                    { 9, "VHS" }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "CategoriesCategoryId", "CategoryId", "Director", "Edited", "Lent_To", "Name", "Notes", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, null, 1, "Robert Zemeckis", true, null, "Forest Gump", "Great", "PG-13", 1994 },
                    { 2, null, 1, "Quentin Tarantino", false, null, "Pulp Fiction", "Great, but no Kids", "R", 1994 },
                    { 3, null, 4, "Ericson Core", false, null, "Togo", "Dog & Alaska", "PG", 2019 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoriesCategoryId",
                table: "Responses",
                column: "CategoriesCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
