using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrderingSystem.Migrations
{
    public partial class tableid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_TableID",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "TableID",
                table: "Reservation",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_TableID",
                table: "Reservation",
                newName: "IX_Reservation_TableId");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_TableId",
                table: "Reservation",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "TableID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Table_TableId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Reservation",
                newName: "TableID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_TableId",
                table: "Reservation",
                newName: "IX_Reservation_TableID");

            migrationBuilder.AlterColumn<int>(
                name: "TableID",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Table_TableID",
                table: "Reservation",
                column: "TableID",
                principalTable: "Table",
                principalColumn: "TableID");
        }
    }
}
