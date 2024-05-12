using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_RoomMate_RoomateId",
                table: "WorkShift");

            migrationBuilder.RenameColumn(
                name: "RoomateId",
                table: "WorkShift",
                newName: "HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkShift_RoomateId",
                table: "WorkShift",
                newName: "IX_WorkShift_HouseId");

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "RoomMate",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valutation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Star = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkShiftId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valutation_WorkShift_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    HouseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prize_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomMate_HouseId",
                table: "RoomMate",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Prize_HouseId",
                table: "Prize",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Valutation_WorkShiftId",
                table: "Valutation",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMate_House_HouseId",
                table: "RoomMate",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShift_House_HouseId",
                table: "WorkShift",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMate_House_HouseId",
                table: "RoomMate");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_House_HouseId",
                table: "WorkShift");

            migrationBuilder.DropTable(
                name: "Prize");

            migrationBuilder.DropTable(
                name: "Valutation");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropIndex(
                name: "IX_RoomMate_HouseId",
                table: "RoomMate");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "RoomMate");

            migrationBuilder.RenameColumn(
                name: "HouseId",
                table: "WorkShift",
                newName: "RoomateId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkShift_HouseId",
                table: "WorkShift",
                newName: "IX_WorkShift_RoomateId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShift_RoomMate_RoomateId",
                table: "WorkShift",
                column: "RoomateId",
                principalTable: "RoomMate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
