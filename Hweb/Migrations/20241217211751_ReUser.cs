using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hweb.Migrations
{
    public partial class ReUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "completed_request_log",
                columns: table => new
                {
                    updateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestID = table.Column<int>(type: "int", nullable: false),
                    request_update_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_completed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_completed_request_log", x => x.updateID);
                });

            migrationBuilder.CreateTable(
                name: "Login_Credentials",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Credentials", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    requestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_submitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.requestID);
                });

            migrationBuilder.CreateTable(
                name: "userRequests",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    requestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRequests", x => new { x.requestID, x.username });
                    table.ForeignKey(
                        name: "FK_userRequests_Requests_requestID",
                        column: x => x.requestID,
                        principalTable: "Requests",
                        principalColumn: "requestID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "completed_request_log");

            migrationBuilder.DropTable(
                name: "Login_Credentials");

            migrationBuilder.DropTable(
                name: "userRequests");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
