using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginClassToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients_List_Data",
                columns: table => new
                {
                    PatientId = table.Column<int>(name: "Patient_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    AdmittedBy = table.Column<int>(name: "Admitted_By", type: "int", nullable: false),
                    AdmittedDate = table.Column<DateTime>(name: "Admitted_Date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients_List_Data", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients_List_Data");
        }
    }
}
