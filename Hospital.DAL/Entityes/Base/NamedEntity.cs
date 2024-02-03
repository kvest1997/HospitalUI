using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
