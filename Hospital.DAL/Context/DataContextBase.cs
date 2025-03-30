using Hospital.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Context
{
    public class DataContextBase : DbContext
    {
        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<ExaminationResult> ExaminationResults { get; set; }
        public virtual DbSet<Hospitals> Hospitals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PrescribedTreatment> PrescribedTreatments { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<OperationTypes> OperationTypes { get; set; }

        public DataContextBase(DbContextOptions<DataContextBase> options) : base(options) { }
    }
}
