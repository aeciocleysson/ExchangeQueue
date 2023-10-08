using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExchangeQueue.Domain.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
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