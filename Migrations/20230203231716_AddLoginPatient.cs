using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients_List_Data",
                table: "Patients_List_Data");

            migrationBuilder.RenameTable(
                name: "Patients_List_Data",
                newName: "Patients_Login_Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients_Login_Data",
                table: "Patients_Login_Data",
                column: "Patient_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients_Login_Data",
                table: "Patients_Login_Data");

            migrationBuilder.RenameTable(
                name: "Patients_Login_Data",
                newName: "Patients_List_Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients_List_Data",
                table: "Patients_List_Data",
                column: "Patient_Id");
        }
    }
}
