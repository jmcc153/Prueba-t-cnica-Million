using MongoDB.Driver;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;

namespace technical_test.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertyRepository(IMongoDatabase database)
        {
            _properties = database.GetCollection<Property>("Property");
        }

        public async Task<Property> CreateProperty(Property property)
        {
            await _properties.InsertOneAsync(property);
            return property;
        }

        public async Task<Property> GetPropertyById(string id)
        {
            return await _properties.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Property>> GetAllProperties()
        {
            return await _properties.Find(_ => true).ToListAsync();
        }

        public async Task<Property> UpdateProperty(Property property)
        {
            await _properties.ReplaceOneAsync(p => p.Id == property.Id, property);
            return property;
        }

        public async Task<bool> DeleteProperty(string id)
        {
            var result = await _properties.DeleteOneAsync(p => p.Id == id);
            return result.DeletedCount > 0;
        }
    }
}