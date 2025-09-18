using technical_test.Application.DTOs.Owner;
using technical_test.Application.DTOs.Property;
using technical_test.Application.Interfaces;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;

namespace technical_test.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;

        public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<Property> CreatePropertyAsync(CreatePropertyDto propertyDto)
        {
            var property = new Property
            {
                Name = propertyDto.Name,
                Address = propertyDto.Address,
                Price = propertyDto.Price,
                CodeInternal = propertyDto.CodeInternal,
                Year = propertyDto.Year,
                OwnerId = propertyDto.OwnerId,
                Traces = propertyDto.Traces?.Select(t => new PropertyTrace
                {
                    DateSale = t.DateSale,
                    Name = t.Name,
                    Value = t.Value,
                    Tax = t.Tax
                }).ToList() ?? new List<PropertyTrace>(),
                Images = propertyDto.Images?.Select(i => new PropertyImage
                {
                    FileUrl = i.FileUrl,
                    Enabled = i.Enabled
                }).ToList() ?? new List<PropertyImage>()

            };
            return await _propertyRepository.CreateProperty(property);
        }

        public async Task<Property> GetPropertyByIdAsync(string id)
        {
            return await _propertyRepository.GetPropertyById(id);
        }

        public async Task<PropertyOwnerResponseDto> GetPropertyOwnerById(string id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                return null;
            }
            Console.WriteLine($"Property found: {property.Name}, OwnerId: {property.OwnerId}");

            var owner = await _ownerRepository.GetOwnerById(property.OwnerId);
            if (owner == null)
            {
                return null;
            }
            var propertyOwnerResponse = new PropertyOwnerResponseDto
            {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                OwnerInfo = new OwnerDto
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    BirthDate = owner.BirthDate,
                    Photo = owner.Photo
                },
                Traces = property.Traces,
                Images = property.Images
            };
            return propertyOwnerResponse;

        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetAllProperties();
        }

        public async Task<Property> UpdatePropertyAsync(UpdatePropertyDto propertyDto)
        {
            var property = new Property
            {
                Id = propertyDto.Id,
                Name = propertyDto.Name,
                Address = propertyDto.Address,
                Price = propertyDto.Price,
                CodeInternal = propertyDto.CodeInternal,
                Year = propertyDto.Year,
                OwnerId = propertyDto.OwnerId,
                Traces = propertyDto.Traces?.Select(t => new PropertyTrace
                {
                    DateSale = t.DateSale,
                    Name = t.Name,
                    Value = t.Value,
                    Tax = t.Tax
                }).ToList() ?? new List<PropertyTrace>(),
                Images = propertyDto.Images?.Select(i => new PropertyImage
                {
                    FileUrl = i.FileUrl,
                    Enabled = i.Enabled
                }).ToList() ?? new List<PropertyImage>()
            };
            return await _propertyRepository.UpdateProperty(property);
        }

        public async Task<bool> DeletePropertyAsync(string id)
        {
            return await _propertyRepository.DeleteProperty(id);
        }
    }
}