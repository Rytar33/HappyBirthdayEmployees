using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyBirthdayEmployees.EmployeesDbConnection.Migrations
{
    /// <inheritdoc />
    public partial class AddIdMessangersEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "employee");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "employee",
                newName: "department");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employee",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "JobPosition",
                table: "employee",
                newName: "job_position");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "employee",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "DateBorn",
                table: "employee",
                newName: "date_born");

            migrationBuilder.AddColumn<long>(
                name: "id_discord",
                table: "employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "id_telegram",
                table: "employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "id_discord",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "id_telegram",
                table: "employee");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "department",
                table: "Employee",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "job_position",
                table: "Employee",
                newName: "JobPosition");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Employee",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "date_born",
                table: "Employee",
                newName: "DateBorn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");
        }
    }
}
