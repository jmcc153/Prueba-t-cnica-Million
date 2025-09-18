using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace technical_test.Core.Entities
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("birthDate")]
        public DateOnly BirthDate { get; set; }
        [BsonElement("photoURL")]
        public byte[] Photo { get; set; }
    }
}
