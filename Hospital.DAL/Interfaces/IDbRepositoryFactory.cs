using Hospital.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Interfaces
{
    public interface IDbRepositoryFactory
    {
        IRepository<T> CreateRepository<T>() where T : Entity, new();
    }
}
