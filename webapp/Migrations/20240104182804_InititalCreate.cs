using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Migrations
{
    /// <inheritdoc />
    public partial class InititalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CW2");

            migrationBuilder.CreateTable(
                name: "FavouriteActivities",
                schema: "CW2",
                columns: table => new
                {
                    FavouriteActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavouriteActivity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteActivities", x => x.FavouriteActivityID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: "CW2",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityTimePreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    MarketingLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileFavouriteActivities",
                schema: "CW2",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FavouriteActivityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileFavouriteActivities", x => new { x.UserID, x.FavouriteActivityID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteActivities",
                schema: "CW2");

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: "CW2");

            migrationBuilder.DropTable(
                name: "UserProfileFavouriteActivities",
                schema: "CW2");
        }
    }
}
