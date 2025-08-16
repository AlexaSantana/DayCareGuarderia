using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayCareGuarderia.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Babysitter",
                columns: table => new
                {
                    BabysitterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Babysitter", x => x.BabysitterId);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ChildId);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Present = table.Column<bool>(type: "bit", nullable: false),
                    BabysitterId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_Babysitter_BabysitterId",
                        column: x => x.BabysitterId,
                        principalTable: "Babysitter",
                        principalColumn: "BabysitterId");
                    table.ForeignKey(
                        name: "FK_Attendance_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parent",
                        principalColumn: "ParentId");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceDetail",
                columns: table => new
                {
                    AttendanceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<int>(type: "int", nullable: false),
                    BabysitterId = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendanceId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDetail", x => x.AttendanceDetailId);
                    table.ForeignKey(
                        name: "FK_AttendanceDetail_Attendance_AttendanceId1",
                        column: x => x.AttendanceId1,
                        principalTable: "Attendance",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceDetail_Babysitter_BabysitterId",
                        column: x => x.BabysitterId,
                        principalTable: "Babysitter",
                        principalColumn: "BabysitterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_BabysitterId",
                table: "Attendance",
                column: "BabysitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ChildId",
                table: "Attendance",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ParentId",
                table: "Attendance",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetail_AttendanceId1",
                table: "AttendanceDetail",
                column: "AttendanceId1");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetail_BabysitterId",
                table: "AttendanceDetail",
                column: "BabysitterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AttendanceDetail");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Babysitter");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Parent");
        }
    }
}
