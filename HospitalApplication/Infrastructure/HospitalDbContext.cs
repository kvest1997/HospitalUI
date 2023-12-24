using System;
using System.Collections.Generic;
using HospitalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analysis> Analyses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<ExaminationResult> ExaminationResults { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PrescribedTreatment> PrescribedTreatments { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HOME-PC\\SQLEXPRESS;Database=HOSPITAL_DB;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analysis>(entity =>
        {
            entity.HasKey(e => e.AnalysesId).HasName("PK__ANALYSES__49294585AF1531B2");

            entity.ToTable("ANALYSES");

            entity.Property(e => e.AnalysesId).HasColumnName("ANALYSES_ID");
            entity.Property(e => e.AnalysesName)
                .HasMaxLength(128)
                .HasColumnName("ANALYSES_NAME");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__APPOINTM__49B308C6CD641B1F");

            entity.ToTable("APPOINTMENT");

            entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
            entity.Property(e => e.DateAppointment).HasColumnName("DATE_APPOINTMENT");
            entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
            entity.Property(e => e.HospitalId).HasColumnName("HOSPITAL_ID");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.TimeAppointment).HasColumnName("TIME_APPOINTMENT");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__APPOINTME__DOCTO__6EF57B66");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__APPOINTME__HOSPI__6E01572D");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__APPOINTME__PATIE__6D0D32F4");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosesId).HasName("PK__DIAGNOSE__8F1B30E4AD0FB7C1");

            entity.ToTable("DIAGNOSES");

            entity.Property(e => e.DiagnosesId).HasColumnName("DIAGNOSES_ID");
            entity.Property(e => e.DiagnosesBlock)
                .HasMaxLength(128)
                .HasColumnName("DIAGNOSES_BLOCK");
            entity.Property(e => e.DiagnosesClass)
                .HasMaxLength(128)
                .HasColumnName("DIAGNOSES_CLASS");
            entity.Property(e => e.DiagnosesName)
                .HasMaxLength(128)
                .HasColumnName("DIAGNOSES_NAME");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__DOCTOR__596ABDB0422EF590");

            entity.ToTable("DOCTOR");

            entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(128)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(128)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.SecondName)
                .HasMaxLength(128)
                .HasColumnName("SECOND_NAME");
            entity.Property(e => e.SpecializationId).HasColumnName("SPECIALIZATION_ID");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DOCTOR__SPECIALI__534D60F1");
        });

        modelBuilder.Entity<ExaminationResult>(entity =>
        {
            entity.HasKey(e => e.ExaminationResultsId).HasName("PK__EXAMINAT__31579086A15A1934");

            entity.ToTable("EXAMINATION_RESULTS");

            entity.Property(e => e.ExaminationResultsId).HasColumnName("EXAMINATION_RESULTS_ID");
            entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
            entity.Property(e => e.DiagnosesId).HasColumnName("DIAGNOSES_ID");
            entity.Property(e => e.DisabilityPeriod).HasColumnName("DISABILITY_PERIOD");
            entity.Property(e => e.Dispansary).HasColumnName("DISPANSARY");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.OutpatientTreatment)
                .HasMaxLength(255)
                .HasColumnName("OUTPATIENT_TREATMENT");

            entity.HasOne(d => d.Appointment).WithMany(p => p.ExaminationResults)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__EXAMINATI__APPOI__71D1E811");

            entity.HasOne(d => d.Diagnoses).WithMany(p => p.ExaminationResults)
                .HasForeignKey(d => d.DiagnosesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__EXAMINATI__DIAGN__72C60C4A");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__HOSPITAL__AAE760882BE1DC51");

            entity.ToTable("HOSPITAL");

            entity.Property(e => e.HospitalId).HasColumnName("HOSPITAL_ID");
            entity.Property(e => e.AdressHospital)
                .HasMaxLength(128)
                .HasColumnName("ADRESS_HOSPITAL");
            entity.Property(e => e.NumberHospital).HasColumnName("NUMBER_HOSPITAL");
            entity.Property(e => e.NumberPhoneHospital).HasColumnName("NUMBER_PHONE_HOSPITAL");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__HOSPITAL__STAFF___59FA5E80");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__PATIENT__AA0B6068236647E6");

            entity.ToTable("PATIENT");

            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(128)
                .HasColumnName("ADRESS");
            entity.Property(e => e.Birthday).HasColumnName("BIRTHDAY");
            entity.Property(e => e.FirstName)
                .HasMaxLength(128)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(128)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.NumberPhone).HasColumnName("NUMBER_PHONE");
            entity.Property(e => e.SecondName)
                .HasMaxLength(128)
                .HasColumnName("SECOND_NAME");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__POSITION__C703B804D6B60343");

            entity.ToTable("POSITIONS");

            entity.Property(e => e.PositionId).HasColumnName("POSITION_ID");
            entity.Property(e => e.PositionName)
                .HasMaxLength(128)
                .HasColumnName("POSITION_NAME");
        });

        modelBuilder.Entity<PrescribedTreatment>(entity =>
        {
            entity.HasKey(e => e.PrescibedTreatmentId).HasName("PK__PRESCRIB__9994348B2395FD02");

            entity.ToTable("PRESCRIBED_TREATMENT");

            entity.Property(e => e.PrescibedTreatmentId).HasColumnName("PRESCIBED_TREATMENT_ID");
            entity.Property(e => e.AnalysesId).HasColumnName("ANALYSES_ID");
            entity.Property(e => e.ExaminationResultsId).HasColumnName("EXAMINATION_RESULTS_ID");
            entity.Property(e => e.Procedur)
                .HasMaxLength(128)
                .HasColumnName("PROCEDUR");
            entity.Property(e => e.Treatment)
                .HasMaxLength(128)
                .HasColumnName("TREATMENT");

            entity.HasOne(d => d.Analyses).WithMany(p => p.PrescribedTreatments)
                .HasForeignKey(d => d.AnalysesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRESCRIBE__ANALY__75A278F5");

            entity.HasOne(d => d.ExaminationResults).WithMany(p => p.PrescribedTreatments)
                .HasForeignKey(d => d.ExaminationResultsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRESCRIBE__EXAMI__76969D2E");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("PK__SPECIALI__57E4BDEBFCE21841");

            entity.ToTable("SPECIALIZATIONS");

            entity.Property(e => e.SpecializationId).HasColumnName("SPECIALIZATION_ID");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(128)
                .HasColumnName("SPECIALIZATION_NAME");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__STAFF__EEFD934E636E5341");

            entity.ToTable("STAFF");

            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
            entity.Property(e => e.NumberDoctor).HasColumnName("NUMBER_DOCTOR");
            entity.Property(e => e.PositionId).HasColumnName("POSITION_ID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__STAFF__DOCTOR_ID__5629CD9C");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__STAFF__POSITION___571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
