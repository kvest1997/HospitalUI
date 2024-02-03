using Hospital.DAL;
using Hospital.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HospitalApplication.Data
{
    class DbInitializer
    {
        private readonly TestDB _db;
        private readonly ILogger<DbInitializer> _Logger;
        public DbInitializer(TestDB db, ILogger<DbInitializer> Logger)
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

            await InitializeCategory();
            await InitializeBooks();
            await InitializeBuyers();
            await InitializeSellers();
            await InitializeDeals();

            _Logger.LogInformation($"Инициализация БД выполнена за {timer.Elapsed.TotalSeconds} с");
        }

        private const int __BooksCount = 10;
        private Book[] _Books;
        private async Task InitializeBooks()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation($"Инициализация Книг...");

            var rand = new Random();


            _Books = Enumerable.Range(1, __BooksCount)
                .Select(i => new Book
                {
                    Name = $"Книга {i}",
                    Category = rand.NextItem<Category>(_Categories)
                })
                .ToArray();

            await _db.Books.AddRangeAsync(_Books);
            await _db.SaveChangesAsync();

            _Logger.LogInformation($"Инициализация Книг выполнена за {timer.ElapsedMilliseconds} мс");
        }

        private const int __CategoriesCount = 10;
        private Category[] _Categories;
        private async Task InitializeCategory()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation($"Инициализация Категорий...");

            _Categories = new Category[__CategoriesCount];
            for (int i = 0; i < __CategoriesCount; i++)
                _Categories[i] = new Category { Name = $"Категория {i + 1}" };
            await _db.Categorys.AddRangeAsync(_Categories);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Категорий выполнена за {timer.ElapsedMilliseconds} мс");

        }

        private const int __SellerCount = 10;
        private Seller[] _Sellers;
        private async Task InitializeSellers()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation($"Инициализация Продавцов...");

            _Sellers = Enumerable.Range(1, __SellerCount)
                .Select(i => new Seller
                {
                    Name = $"Продавец-Имя {i}",
                    Surname = $"Продавец-Фамилия {i}",
                    Patronymic = $"Продавец-Отчество {i}"
                })
                .ToArray();

            await _db.Sellers.AddRangeAsync(_Sellers);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Продавцов выполнена за {timer.ElapsedMilliseconds} мс");

        }

        private const int __BuyerCount = 10;
        private Buyer[] _Buyers;
        private async Task InitializeBuyers()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation($"Инициализация Покупателей...");

            _Buyers = Enumerable.Range(1, __BuyerCount)
                .Select(i => new Buyer
                {
                    Name =$"Покупатель-Имя {i}",
                    Surname=$"Покупатель-Фамилия {i}",
                    Patronymic = $"Покупатель-Отчество {i}"
                })
                .ToArray();

            await _db.Buyers.AddRangeAsync(_Buyers);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Покупателей выполнена за {timer.ElapsedMilliseconds} мс");

        }

        private const int __DealCount = 1000;
        
        private async Task InitializeDeals()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation($"Инициализация Сделок...");

            Random rand = new Random();

            var _Deals = Enumerable.Range(1, __DealCount)
                .Select(i => new Deal
                {
                    Book = rand.NextItem(_Books),
                    Seller = rand.NextItem(_Sellers),
                    Buyer = rand.NextItem(_Buyers),
                    Price = (decimal)(rand.NextDouble() * 4000 + 700)
                });

            await _db.Deals.AddRangeAsync(_Deals);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Сделок выполнена за {timer.ElapsedMilliseconds} мс");

        }
    }
}
