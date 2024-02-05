using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Management.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialDataBase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "LeaveTypes",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DefaultDay = table.Column<int>(type: "int", nullable: false),
                CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LeaveTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "LeaveAllocations",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NumberOfDays = table.Column<int>(type: "int", nullable: false),
                LeaveTypeId = table.Column<long>(type: "bigint", nullable: false),
                Priod = table.Column<int>(type: "int", nullable: false),
                CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LeaveAllocations", x => x.Id);
                table.ForeignKey(
                    name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                    column: x => x.LeaveTypeId,
                    principalTable: "LeaveTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "LeaveRequests",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LeaveTypeId = table.Column<long>(type: "bigint", nullable: false),
                RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsApprove = table.Column<bool>(type: "bit", nullable: false),
                IsCancel = table.Column<bool>(type: "bit", nullable: false),
                CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                table.ForeignKey(
                    name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                    column: x => x.LeaveTypeId,
                    principalTable: "LeaveTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_LeaveAllocations_LeaveTypeId",
            table: "LeaveAllocations",
            column: "LeaveTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_LeaveRequests_LeaveTypeId",
            table: "LeaveRequests",
            column: "LeaveTypeId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "LeaveAllocations");

        migrationBuilder.DropTable(
            name: "LeaveRequests");

        migrationBuilder.DropTable(
            name: "LeaveTypes");
    }
}
