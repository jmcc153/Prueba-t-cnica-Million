using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace technical_test.Core.Entities
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }

        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public string OwnerId { get; set; }
        public List<PropertyTrace> Traces { get; set; }
        public List<PropertyImage> Images { get; set; }
    }
}
