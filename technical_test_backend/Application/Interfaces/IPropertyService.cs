using technical_test.Application.DTOs.Property;
using technical_test.Core.Entities;

namespace technical_test.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyResponseDto> CreatePropertyAsync(CreatePropertyDto property);
        Task<PropertyResponseDto> GetPropertyByIdAsync(string id);
        Task<List<PropertyResponseDto>> GetAllPropertiesAsync(string? name, string? address, double? priceMin, double? priceMax);
        Task<PropertyOwnerResponseDto> GetPropertyOwnerById(string id);
        Task<PropertyResponseDto> UpdatePropertyAsync(UpdatePropertyDto property);
        Task<bool> DeletePropertyAsync(string id);
    }
}