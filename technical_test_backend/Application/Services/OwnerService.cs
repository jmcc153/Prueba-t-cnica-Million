using technical_test.Application.DTOs.Owner;
using technical_test.Application.Interfaces;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;

namespace technical_test.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Owner> CreateOwnerAsync(CreateOwnerDto createOwnerDto)
        {
            var owner = new Owner
            {
                Name = createOwnerDto.Name,
                Address = createOwnerDto.Address,
                BirthDate = createOwnerDto.BirthDate,
                PhotoURL = createOwnerDto.PhotoURL
            };

            return await _ownerRepository.CreateOwner(owner);
        }

        public async Task<Owner?> GetOwnerByIdAsync(string id)
        {
            return await _ownerRepository.GetOwnerById(id);
        }

        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllOwners();
        }

        public async Task<Owner> UpdateOwnerAsync(UpdateOwnerDto updateOwnerDto)
        {
            var owner = new Owner
            {
                Id = updateOwnerDto.Id,
                Name = updateOwnerDto.Name,
                Address = updateOwnerDto.Address,
                BirthDate = updateOwnerDto.BirthDate,
                PhotoURL = updateOwnerDto.PhotoURL
            };

            return await _ownerRepository.UpdateOwner(owner);
        }

        public async Task<bool> DeleteOwnerAsync(string id)
        {
            return await _ownerRepository.DeleteOwner(id);
        }
    }
}