using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Hospital.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Hospital.DAL.Entityes;

namespace Hospital.DAL
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DataContextBase _db;
        private readonly DbSet<T> _Set;

        public bool AutoSaveChanges { get; set; } = true; 

        public DbRepository(DataContextBase db)
        {
            _db = db;
            _Set = db.Set<T>();
        }
        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(item).State = EntityState.Added;

                    if(AutoSaveChanges)
                        _db.SaveChanges();

                    return item;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    _db.Entry(item).State = EntityState.Added;

                    if (AutoSaveChanges)
                        await _db.SaveChangesAsync().ConfigureAwait(false);

                    await transaction.CommitAsync();
                    return item;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }            
        }

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
            .SingleOrDefaultAsync(item => item.Id == id, Cancel)
            .ConfigureAwait(false);

        public void Remove(int id)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var itemRemove = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

                    _db.Remove(itemRemove);

                    if (AutoSaveChanges)
                        _db.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }


            if (AutoSaveChanges)
                 _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var itemRemove = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

                    _db.Remove(itemRemove);

                    if (AutoSaveChanges)
                        await _db.SaveChangesAsync().ConfigureAwait(false);

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;

            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    _db.Entry(item).State = EntityState.Modified;

                    if (AutoSaveChanges)
                        await _db.SaveChangesAsync().ConfigureAwait(false);

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }

    class StaffRepository : DbRepository<Staff>
    {
        public override IQueryable<Staff> Items => 
            base.Items
            .Include(item => item.Doctor)
            .Include(item => item.Position);

        public StaffRepository(DataContextBase db) : base(db)
        {
        }
    }

    class PrescribedTreatmentsRepository : DbRepository<PrescribedTreatment>
    {
        public override IQueryable<PrescribedTreatment> Items =>
            base.Items
            .Include(item => item.Analyses)
            .Include(item => item.ExaminationResults);

        public PrescribedTreatmentsRepository(DataContextBase db) : base(db)
        {
        }
    }

    class HospitalRepository : DbRepository<Hospitals>
    {
        public override IQueryable<Hospitals> Items =>
            base.Items
            .Include(item => item.Staff);

        public HospitalRepository(DataContextBase db) : base(db)
        {
        }
    }

    class ExaminationResultsRepository : DbRepository<ExaminationResult>
    {
        public override IQueryable<ExaminationResult> Items =>
            base.Items
            .Include(item => item.Appointment)
            .Include(item => item.Diagnoses);

        public ExaminationResultsRepository(DataContextBase db) : base(db)
        {
        }
    }

    class DoctorsRepository : DbRepository<Doctor>
    {
        public override IQueryable<Doctor> Items =>
            base.Items
            .Include(item => item.Specialization);

        public DoctorsRepository(DataContextBase db) : base(db)
        {
        }
    }

    class AppointmentsRepository : DbRepository<Appointment>
    {
        public override IQueryable<Appointment> Items =>
            base.Items
            .Include(item => item.Hospital)
            .Include(item => item.Doctor)
            .Include(item => item.Patient)
            .Include(item => item.ExaminationResults);

        public AppointmentsRepository(DataContextBase db) : base(db)
        {
        }
    }

    class PatientRepository : DbRepository<Patient>
    {
        public override IQueryable<Patient> Items => base.Items
            .Include(item => item.Appointments)
                .ThenInclude(item => item.Hospital)
            .Include(item => item.Appointments)
                .ThenInclude(item => item.Doctor)
            .Include(item => item.Appointments)
                .ThenInclude(item => item.ExaminationResults)
                    .ThenInclude(item => item.Diagnoses)
            .Include(item => item.Appointments)
                .ThenInclude(item => item.ExaminationResults)
                    .ThenInclude(item => item.PrescribedTreatments)
                        .ThenInclude(item => item.Analyses)
            .Include(item=>  item.Operations);
        

        public PatientRepository(DataContextBase db) : base(db)
        {
        }
    }
}
