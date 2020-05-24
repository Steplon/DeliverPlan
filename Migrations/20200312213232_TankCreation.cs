using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliverPlan.Migrations
{
    public partial class TankCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tank_Customer_CustomerID",
                table: "Tank");

            migrationBuilder.DropIndex(
                name: "IX_Tank_CustomerID",
                table: "Tank");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Tank",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Tank",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Tank_CustomerID",
                table: "Tank",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tank_Customer_CustomerID",
                table: "Tank",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
