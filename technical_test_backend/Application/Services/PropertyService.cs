using technical_test.Application.Interfaces;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;

namespace technical_test.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            // Aquí puedes agregar validaciones de negocio
            return await _propertyRepository.CreateProperty(property);
        }

        public async Task<Property> GetPropertyByIdAsync(string id)
        {
            return await _propertyRepository.GetPropertyById(id);
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetAllProperties();
        }

        public async Task<Property> UpdatePropertyAsync(Property property)
        {
            // Aquí puedes agregar validaciones de negocio
            return await _propertyRepository.UpdateProperty(property);
        }

        public async Task<bool> DeletePropertyAsync(string id)
        {
            return await _propertyRepository.DeleteProperty(id);
        }
    }
}