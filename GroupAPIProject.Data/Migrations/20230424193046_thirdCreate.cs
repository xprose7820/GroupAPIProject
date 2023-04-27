using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupAPIProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class thirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_InventoryItems_InventoryItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_InventoryItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "SalesOrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryItemId",
                table: "SalesOrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_InventoryItemId",
                table: "SalesOrderItems",
                column: "InventoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_InventoryItems_InventoryItemId",
                table: "SalesOrderItems",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
