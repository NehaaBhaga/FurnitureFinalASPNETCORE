using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICapstoneProject.Migrations.OrderRequestDB
{
    /// <inheritdoc />
    public partial class OrderRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnitureNeeded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentNeeded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.Uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRequests");
        }
    }
}
