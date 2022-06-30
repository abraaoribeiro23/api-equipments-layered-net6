using System.ComponentModel.DataAnnotations;

namespace Aiko.Domain.Bases
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
