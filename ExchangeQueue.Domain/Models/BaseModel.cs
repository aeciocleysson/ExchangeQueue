using System.ComponentModel.DataAnnotations;

namespace ExchangeQueue.Domain.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}