using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API2.Migrations
{
    public partial class examenDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CiudadItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    establecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroStars = table.Column<int>(type: "int", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadItem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    establecimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    numeroStars = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CiudadItem");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
