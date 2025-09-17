using technical_test.Core.Entities;

namespace technical_test.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> CreatePropertyAsync(Property property);
        Task<Property> GetPropertyByIdAsync(string id);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Property> UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(string id);
    }
}