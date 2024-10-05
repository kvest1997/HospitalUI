using Hospital.Interfaces;

namespace Hospital.DAL.Entityes.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
