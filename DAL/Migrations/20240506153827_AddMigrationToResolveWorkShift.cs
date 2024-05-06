using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationToResolveWorkShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HouseWorkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoomateId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShift_HouseWork_HouseWorkId",
                        column: x => x.HouseWorkId,
                        principalTable: "HouseWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShift_RoomMate_RoomateId",
                        column: x => x.RoomateId,
                        principalTable: "RoomMate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_HouseWorkId",
                table: "WorkShift",
                column: "HouseWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_RoomateId",
                table: "WorkShift",
                column: "RoomateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkShift");
        }
    }
}
