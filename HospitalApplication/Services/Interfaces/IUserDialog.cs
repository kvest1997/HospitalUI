using Hospital.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Add(Patient patient);
    }
}
