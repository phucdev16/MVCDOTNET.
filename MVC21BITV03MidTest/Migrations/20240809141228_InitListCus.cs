using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC21BITV03MidTest.Migrations
{
    /// <inheritdoc />
    public partial class InitListCus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "ListCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListCustomers_SaleId",
                table: "ListCustomers",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListCustomers_Sales_SaleId",
                table: "ListCustomers",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListCustomers_Sales_SaleId",
                table: "ListCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ListCustomers_SaleId",
                table: "ListCustomers");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "ListCustomers");
        }
    }
}
