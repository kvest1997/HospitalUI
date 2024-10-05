﻿// <auto-generated />
using System;
using Hospital.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.DAL.Migrations
{
    [DbContext(typeof(DataContextBase))]
    partial class DataContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Hospital.DAL.Entityes.Analysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnalysesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateAppointment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeAppointment")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiagnosesBlock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosesClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.ExaminationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DiagnosesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DisabilityPeriod")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Dispansary")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutpatientTreatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DiagnosesId");

                    b.ToTable("ExaminationResults");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdressHospital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberHospital")
                        .HasColumnType("int");

                    b.Property<int>("NumberPhoneHospital")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberPhone")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.PrescribedTreatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnalysesId")
                        .HasColumnType("int");

                    b.Property<int?>("ExaminationResultsId")
                        .HasColumnType("int");

                    b.Property<string>("Procedur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalysesId");

                    b.HasIndex("ExaminationResultsId");

                    b.ToTable("PrescribedTreatments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SpecializationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberDoctor")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PositionId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Appointment", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Hospital.DAL.Entityes.Hospital", "Hospital")
                        .WithMany("Appointments")
                        .HasForeignKey("HospitalId");

                    b.HasOne("Hospital.DAL.Entityes.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Hospital");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Doctor", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.ExaminationResult", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Appointment", "Appointment")
                        .WithMany("ExaminationResults")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("Hospital.DAL.Entityes.Diagnosis", "Diagnoses")
                        .WithMany("ExaminationResults")
                        .HasForeignKey("DiagnosesId");

                    b.Navigation("Appointment");

                    b.Navigation("Diagnoses");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Hospital", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Staff", "Staff")
                        .WithMany("Hospitals")
                        .HasForeignKey("StaffId");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.PrescribedTreatment", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Analysis", "Analyses")
                        .WithMany("PrescribedTreatments")
                        .HasForeignKey("AnalysesId");

                    b.HasOne("Hospital.DAL.Entityes.ExaminationResult", "ExaminationResults")
                        .WithMany("PrescribedTreatments")
                        .HasForeignKey("ExaminationResultsId");

                    b.Navigation("Analyses");

                    b.Navigation("ExaminationResults");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Staff", b =>
                {
                    b.HasOne("Hospital.DAL.Entityes.Doctor", "Doctor")
                        .WithMany("Staff")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Hospital.DAL.Entityes.Position", "Position")
                        .WithMany("staff")
                        .HasForeignKey("PositionId");

                    b.Navigation("Doctor");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Analysis", b =>
                {
                    b.Navigation("PrescribedTreatments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Appointment", b =>
                {
                    b.Navigation("ExaminationResults");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Diagnosis", b =>
                {
                    b.Navigation("ExaminationResults");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.ExaminationResult", b =>
                {
                    b.Navigation("PrescribedTreatments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Hospital", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Position", b =>
                {
                    b.Navigation("staff");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Hospital.DAL.Entityes.Staff", b =>
                {
                    b.Navigation("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
