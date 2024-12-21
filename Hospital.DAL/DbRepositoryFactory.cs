using Hospital.DAL.Context;
using Hospital.DAL.Entityes;
using Hospital.DAL.Entityes.Base;
using Hospital.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hospital.DAL
{
    public class DbRepositoryFactory : IDbRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        IRepository<T> IDbRepositoryFactory.CreateRepository<T>() => _serviceProvider.GetRequiredService<IRepository<T>>();
    }
}
