using technical_test.Application.DTOs.Property;
using technical_test.Core.Entities;

namespace technical_test.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> CreatePropertyAsync(CreatePropertyDto property);
        Task<Property> GetPropertyByIdAsync(string id);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<PropertyOwnerResponseDto> GetPropertyOwnerById(string id);
        Task<Property> UpdatePropertyAsync(UpdatePropertyDto property);
        Task<bool> DeletePropertyAsync(string id);
    }
}