using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddchangesToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patient_Name",
                table: "Patients_Login_Data");

            migrationBuilder.DropColumn(
                name: "Ph_Number",
                table: "Patients_Login_Data");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Patients_Login_Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patient_Name",
                table: "Patients_Login_Data",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Ph_Number",
                table: "Patients_Login_Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Patients_Login_Data",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
