using Hospital.DAL.Entityes.Base;
using System.Collections.Generic;

namespace Hospital.DAL.Entityes
{
    public partial class OperationTypes : Entity
    {
        public OperationTypes()
        {
            Operations = new HashSet<Operations>();
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Operations> Operations { get; set; }
    }
}