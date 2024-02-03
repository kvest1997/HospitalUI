using Hospital.DAL.Entityes.Base;
using System.Collections.Generic;

namespace Hospital.DAL
{
    public class Category : NamedEntity
    {
        public virtual ICollection<Book> Books { get; set; }
    }

}
