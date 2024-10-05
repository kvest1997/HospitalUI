using Hospital.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Context
{
    public class DataContextBase : DbContext
    {

        public DataContextBase(DbContextOptions options) : base(options) { }
    }
}
