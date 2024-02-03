using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Tools
{
    static class RandomExtensions
    {
        public static T NextItem<T>(this Random rand, params T[] items) => items[rand.Next(items.Length)];
    }
}
