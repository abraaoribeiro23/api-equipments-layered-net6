using System.ComponentModel.DataAnnotations;

namespace Domain.Bases
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
