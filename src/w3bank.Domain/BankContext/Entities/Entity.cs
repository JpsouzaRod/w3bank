using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace w3bank.Domain.BankContext.Entities
{
    public class Entity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
    }
}