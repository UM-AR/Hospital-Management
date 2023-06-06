using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients_List",
                columns: table => new
                {
                    PatientId = table.Column<int>(name: "Patient_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(name: "Patient_Name", type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    AdmittedBy = table.Column<int>(name: "Admitted_By", type: "int", nullable: false),
                    AdmittedDate = table.Column<DateTime>(name: "Admitted_Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients_List", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients_List");
        }
    }
}
