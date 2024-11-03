﻿using Hospital.DAL;
using Hospital.DAL.Context;
using Hospital.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HospitalApplication.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,
            IConfiguration configuration) => services
            .AddDbContext<DataContextBase>(opt =>
            {
                var type = configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определён тип БД");

                    default: throw new InvalidOperationException($"Тип подклчения {type} не поддерживается");

                    case "MSSQL":
                        opt.UseSqlServer(configuration.GetConnectionString(type));
                        break;
                    case "SQLite":
                        opt.UseSqlite(configuration.GetConnectionString(type));
                        break;
                    case "InMemory":
                        opt.UseInMemoryDatabase("Hospital.db");
                        break;
                }
            })
            .AddTransient<DbInitializer>()
            .AddRepositoruesInDB()
            ;
    }
}
