using Hospital.DAL.Context;
using Hospital.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HospitalApplication.Data
{
    class DbInitializer
    {
        private readonly DataContextBase _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(DataContextBase db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация БД...");

            //_Logger.LogInformation("Удалдение существубщей БД...");
            //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //_Logger.LogInformation($"Удаление существующей БД выполнено за {timer.ElapsedMilliseconds} мс");
            //_db.Database.EnsureCreated();
            //_Logger.LogInformation("Миграция БД...");
            //await _db.Database.MigrateAsync().ConfigureAwait(false);
            //_Logger.LogInformation($"Миграция БД выполненан за {timer.ElapsedMilliseconds} мс");

            #region Добавление тестовых данных - !!!ДЛЯ ПЕРВОГО ЗАПУСКА
            //await InitializeAnalyses();
            //await InitializePatients();
            //await InitializeSpecialization();
            //await InitializePositions();
            //await InitializeDoctors();
            //await InitializeStaffs();
            //await InitializeHospitals();
            //await InitializeDiagnoses();
            #endregion

            _Logger.LogInformation($"Инициализация БД выполнена за {timer.Elapsed.TotalSeconds} с");
        }
        
        private async Task InitializeDiagnoses()
        {
            Diagnosis[] _diagnoses;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация диазнозов...");

            _diagnoses = new Diagnosis[10];
            for (int i = 0; i < 10; i++)
            {
                _diagnoses[i] = new Diagnosis 
                { 
                    DiagnosesBlock = $"Блок диагноза {i}", 
                    DiagnosesClass = $"Класс диагонза {i}", 
                    DiagnosesName = $"Название диагноза {i}" 
                };
            }

            await _db.Diagnoses.AddRangeAsync(_diagnoses);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация диазнозов выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private async Task InitializeAnalyses()
        {
            Analysis[] _analyses;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация анализов...");

            _analyses = new Analysis[10];
            for (int i = 0; i < 10; i++)
            {
                _analyses[i] = new Analysis { AnalysesName = $"Анализ {i}" };
            }

            await _db.Analyses.AddRangeAsync(_analyses);
            await _db.SaveChangesAsync();


            _Logger.LogInformation($"Инициализация анализов выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private async Task InitializePatients()
        {
            Patient[] _patients;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация пациента...");

            _patients = new Patient[10];
            for (var i = 0; i < 10; i++)
                _patients[i] = new Patient { SecondName = $"Фамилия пациента {i}", FirstName = $"Имя пациента {i}", LastName =$"Отчество пациента {i}", Birthday= DateTime.Now, Adress=$"Адрес пациента {i}", NumberPhone = 8953+i+i+1 };

            await _db.Patients.AddRangeAsync(_patients);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация пациента выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private async Task InitializeSpecialization()
        {
            Specialization[] _specializations;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация специализации");

            _specializations = new Specialization[10];

            for (var i = 0; i < 10; i++)
            {
                _specializations[i] = new Specialization { SpecializationName = $"Специализация {i}"};
            }

            await _db.Specializations.AddRangeAsync(_specializations);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация специализации выполнена за {timer.ElapsedMilliseconds} мс");

        }

        private async Task InitializePositions()
        {
            Position[] _positions;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация должности");

            _positions = new Position[10];

            for (var i = 0; i < 10; i++)
            {
                _positions[i] = new Position { PositionName = $"Должность {i}" };
            }

            await _db.Positions.AddRangeAsync(_positions);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация должности выполнена за {timer.ElapsedMilliseconds} мс");

        }

        private async Task InitializeDoctors()
        {
            Doctor[] _doctors;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация докторов");

            _doctors = new Doctor[10];

            for(var i = 0; i< 10; i++)
            {
                _doctors[i] = new Doctor { SecondName = $"Фамилия доктора{i}", FirstName = $"Имя доктора{i}", LastName = $"Отчество доктора{i}", SpecializationId = i+1 };
            }

            await _db.Doctors.AddRangeAsync(_doctors);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация докторов выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private async Task InitializeStaffs()
        {
            Staff[] _staffs;
         
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация персонала");

            _staffs = new Staff[10];

            for (var i = 0; i < 10; i++)
            {
                _staffs[i] = new Staff { NumberDoctor = 893 + i, DoctorId = i+1, PositionId = i+1 };
            }

            await _db.Staff.AddRangeAsync(_staffs);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация персонала выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private async Task InitializeHospitals()
        {
            Hospitals[] _hospitals;

            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация больниц");

            _hospitals = new Hospitals[10];

            for (var i = 0; i < 10; i++)
            {
                _hospitals[i] = new Hospitals { NumberPhoneHospital = 893 + i, NumberHospital = i, StaffId = i+1, AdressHospital = $"Улица {i}" };
            }

            await _db.Hospitals.AddRangeAsync(_hospitals);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация больниц выполнена за {timer.ElapsedMilliseconds} мс");
        }
    }
}
