using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace technical_test.Core.Entities
{
    public class PropertyTrace
    {
        public DateOnly DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
