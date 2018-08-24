using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCore.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activity_item_activity_activity_id",
                table: "activity_item");

            migrationBuilder.AddForeignKey(
                name: "FK_activity_item_activity_activity_id",
                table: "activity_item",
                column: "activity_id",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activity_item_activity_activity_id",
                table: "activity_item");

            migrationBuilder.AddForeignKey(
                name: "FK_activity_item_activity_activity_id",
                table: "activity_item",
                column: "activity_id",
                principalTable: "activity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
