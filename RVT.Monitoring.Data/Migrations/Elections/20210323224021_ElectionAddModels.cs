using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RVT.Monitoring.data.Migrations.Elections
{
    public partial class ElectionAddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectionTypes",
                columns: table => new
                {
                    ElectionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionTypes", x => x.ElectionTypeId);
                    table.ForeignKey(
                        name: "FK_ElectionTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    ElectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElectionShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ElectionFullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AditionalInfo = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ElectionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManualCloseUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CaseManualClosure = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.ElectionId);
                    table.ForeignKey(
                        name: "FK_Elections_ElectionTypes_ElectionTypeId",
                        column: x => x.ElectionTypeId,
                        principalTable: "ElectionTypes",
                        principalColumn: "ElectionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elections_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elections_Users_ManualCloseUserId",
                        column: x => x.ManualCloseUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elections_CreatedById",
                table: "Elections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_ElectionTypeId",
                table: "Elections",
                column: "ElectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_ManualCloseUserId",
                table: "Elections",
                column: "ManualCloseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTypes_CreatedById",
                table: "ElectionTypes",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "ElectionTypes");
        }
    }
}
