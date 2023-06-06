using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveADmittedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admitted_By",
                table: "Patients_Login_Data");

            migrationBuilder.DropColumn(
                name: "Admitted_Date",
                table: "Patients_Login_Data");

            migrationBuilder.DropColumn(
                name: "Admitted_By",
                table: "Patients_List");

            migrationBuilder.DropColumn(
                name: "Admitted_Date",
                table: "Patients_List");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Admitted_By",
                table: "Patients_Login_Data",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Admitted_Date",
                table: "Patients_Login_Data",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Admitted_By",
                table: "Patients_List",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Admitted_Date",
                table: "Patients_List",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
