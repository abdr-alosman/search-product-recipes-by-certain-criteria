using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchProductCode.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogoRecips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LINETYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineProductDef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoRecips", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogoRecips");
        }
    }
}
