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

        // Método helper para convertir IFormFile a byte[]
        private async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task<PropertyResponseDto> CreatePropertyAsync(CreatePropertyDto propertyDto)
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
                Images = new List<PropertyImage>()
            };

            // Convertir IFormFile a byte[] para cada imagen
            if (propertyDto.Images != null && propertyDto.Images.Any())
            {
                foreach (var imageDto in propertyDto.Images)
                {
                    var imageBytes = await ConvertToByteArrayAsync(imageDto.FileUrl);
                    if (imageBytes != null)
                    {
                        property.Images.Add(new PropertyImage
                        {
                            FileUrl = imageBytes,
                            Enabled = imageDto.Enabled
                        });
                    }
                }
            }

            var createdProperty = await _propertyRepository.CreateProperty(property);
            
            return new PropertyResponseDto
            {
                Id = createdProperty.Id,
                Name = createdProperty.Name,
                Address = createdProperty.Address,
                Price = createdProperty.Price,
                CodeInternal = createdProperty.CodeInternal,
                Year = createdProperty.Year,
                OwnerId = createdProperty.OwnerId,
                Traces = createdProperty?.Traces?.Select(t => new PropertyTraceDto
                {
                    DateSale = t.DateSale,
                    Name = t.Name,
                    Value = t.Value,
                    Tax = t.Tax
                }).ToList(),
                Images = createdProperty?.Images?.Select(i => new PropertyImageDto
                {
                    FileData = i.FileUrl,
                    Enabled = i.Enabled
                }).ToList()
            };
        }

        public async Task<PropertyResponseDto> GetPropertyByIdAsync(string id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                return null;
            }
            return new PropertyResponseDto
            {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                OwnerId = property.OwnerId,
                Traces = property?.Traces?.Select(t => new PropertyTraceDto
                {
                    DateSale = t.DateSale,
                    Name = t.Name,
                    Value = t.Value,
                    Tax = t.Tax
                }).ToList(),
                Images = property?.Images?.Where(i => i.Enabled && i.FileUrl != null)
                        .Select(i => new PropertyImageDto
                        {
                            FileData = i.FileUrl,
                            Enabled = i.Enabled
                        }).ToList()
            };
        }

        public async Task<PropertyOwnerResponseDto> GetPropertyOwnerById(string id)
        {
            var property = await _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                return null;
            }

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
                OwnerId = property.OwnerId,
                OwnerInfo = new OwnerDto
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    BirthDate = owner.BirthDate,
                    Photo = owner.Photo
                },
                Traces = property.Traces?.Select(trace => new PropertyTraceDto
                {
                    DateSale = trace.DateSale,
                    Name = trace.Name,
                    Value = trace.Value,
                    Tax = trace.Tax
                }).ToList(),
                Images = property.Images?.Where(img => img.Enabled && img.FileUrl != null)
                        .Select(img => new PropertyImageDto
                        {
                            FileData = img.FileUrl,
                            Enabled = img.Enabled
                        }).ToList()
            };
            return propertyOwnerResponse;
        }

        public async Task<List<PropertyResponseDto>> GetAllPropertiesAsync(string? name, string? address, double? priceMin, double? priceMax)
        {
            var properties = await _propertyRepository.GetAllProperties();
            if (!string.IsNullOrEmpty(name))
            {
                properties = properties.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(address))
            {
                properties = properties.Where(p => p.Address.Contains(address, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (priceMin.HasValue)
            {
                properties = properties.Where(p => p.Price >= priceMin.Value).ToList();
            }
            if (priceMax.HasValue)
            {
                properties = properties.Where(p => p.Price <= priceMax.Value).ToList();
            }
            
            return properties.Select(property => new PropertyResponseDto
            {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                OwnerId = property.OwnerId
            }).ToList();
        }

        public async Task<PropertyResponseDto> UpdatePropertyAsync(UpdatePropertyDto propertyDto)
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
                Images = new List<PropertyImage>()
            };

            // Convertir IFormFile a byte[] para cada imagen
            if (propertyDto.Images != null && propertyDto.Images.Any())
            {
                foreach (var imageDto in propertyDto.Images)
                {
                    var imageBytes = await ConvertToByteArrayAsync(imageDto.FileUrl);
                    if (imageBytes != null)
                    {
                        property.Images.Add(new PropertyImage
                        {
                            FileUrl = imageBytes,
                            Enabled = imageDto.Enabled
                        });
                    }
                }
            }

            var updatedProperty = await _propertyRepository.UpdateProperty(property);
            
            return new PropertyResponseDto
            {
                Id = updatedProperty.Id,
                Name = updatedProperty.Name,
                Address = updatedProperty.Address,
                Price = updatedProperty.Price,
                CodeInternal = updatedProperty.CodeInternal,
                Year = updatedProperty.Year,
                OwnerId = updatedProperty.OwnerId,
                Traces = updatedProperty?.Traces?.Select(t => new PropertyTraceDto
                {
                    DateSale = t.DateSale,
                    Name = t.Name,
                    Value = t.Value,
                    Tax = t.Tax
                }).ToList(),
                Images = updatedProperty?.Images?.Where(i => i.Enabled && i.FileUrl != null)
                        .Select(i => new PropertyImageDto
                        {
                            FileData = i.FileUrl,
                            Enabled = i.Enabled
                        }).ToList()
            };
        }

        public async Task<bool> DeletePropertyAsync(string id)
        {
            return await _propertyRepository.DeleteProperty(id);
        }
    }
}