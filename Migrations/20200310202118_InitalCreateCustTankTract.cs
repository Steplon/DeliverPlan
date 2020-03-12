using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliverPlan.Migrations
{
    public partial class InitalCreateCustTankTract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tractor",
                columns: table => new
                {
                    Tag = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tractor", x => x.Tag);
                });

            migrationBuilder.CreateTable(
                name: "Tank",
                columns: table => new
                {
                    Tag = table.Column<string>(nullable: false),
                    Level = table.Column<double>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    CustomerID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tank", x => x.Tag);
                    table.ForeignKey(
                        name: "FK_Tank_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tank_CustomerID",
                table: "Tank",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tank");

            migrationBuilder.DropTable(
                name: "Tractor");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
