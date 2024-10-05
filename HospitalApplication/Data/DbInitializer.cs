using Hospital.DAL.Context;
using Hospital.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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

            _Logger.LogInformation("Удалдение существубщей БД...");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _Logger.LogInformation($"Удаление существующей БД выполнено за {timer.ElapsedMilliseconds} мс");

            _Logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync().ConfigureAwait(false);
            _Logger.LogInformation($"Миграция БД выполненан за {timer.ElapsedMilliseconds} мс");

            //if (await _db.Books.AnyAsync()) return;


            _Logger.LogInformation($"Инициализация БД выполнена за {timer.Elapsed.TotalSeconds} с");
        }

    }
}
