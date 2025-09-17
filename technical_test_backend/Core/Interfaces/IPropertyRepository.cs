using technical_test.Core.Entities;

namespace technical_test.Core.Interfaces
{
    public interface IPropertyRepository
    {
        Task<Property> CreateProperty(Property property);
        Task<Property> GetPropertyById(string id);
        Task<List<Property>> GetAllProperties();
        Task<Property> UpdateProperty(Property property);
        Task<bool> DeleteProperty(string id);
    }
}
