using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace HR_Management.Persistence.Migrations;

/// <inheritdoc />
public partial class LeaveTypeSeedData : Migration
{
    private static readonly string[] columns = ["Id", "CreateDate", "CreatedBy", "DefaultDay", "LastModifyBy", "LastModifyDate", "Name"];

    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "LeaveTypes",
            columns: columns,
            values: new object[,]
            {
                { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacation" },
                { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "LeaveTypes",
            keyColumn: "Id",
            keyValue: 1L);

        migrationBuilder.DeleteData(
            table: "LeaveTypes",
            keyColumn: "Id",
            keyValue: 2L);
    }
}
