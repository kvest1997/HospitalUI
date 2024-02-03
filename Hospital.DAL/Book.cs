using Hospital.DAL.Entityes.Base;

namespace Hospital.DAL
{
    public class Book : NamedEntity
    {
        public virtual Category Category { get; set; }
    }

}
