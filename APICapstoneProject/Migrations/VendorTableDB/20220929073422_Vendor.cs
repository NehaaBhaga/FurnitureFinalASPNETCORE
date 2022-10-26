using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICapstoneProject.Migrations.VendorTableDB
{
    /// <inheritdoc />
    public partial class Vendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendorTables",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnitureNeeded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentNeeded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorTables", x => x.Uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorTables");
        }
    }
}
