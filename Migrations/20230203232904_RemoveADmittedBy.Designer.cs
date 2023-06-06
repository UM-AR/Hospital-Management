﻿// <auto-generated />
using Hospital_Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Migrations
{
    [DbContext(typeof(HospitalManager))]
    [Migration("20230203232904_RemoveADmittedBy")]
    partial class RemoveADmittedBy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_Management.DB_Classes.Patient", b =>
                {
                    b.Property<int>("Patient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ph_Number")
                        .HasColumnType("float");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Patient_Id");

                    b.ToTable("Patients_List");
                });

            modelBuilder.Entity("Hospital_Management.DB_Classes.Patient_Login", b =>
                {
                    b.Property<int>("Patient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Patient_Id");

                    b.ToTable("Patients_Login_Data");
                });
#pragma warning restore 612, 618
        }
    }
}
