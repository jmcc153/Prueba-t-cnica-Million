using Microsoft.AspNetCore.Http.HttpResults;
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
            byte[] photoBytes = null;
            
            if (createOwnerDto.Photo != null && createOwnerDto.Photo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await createOwnerDto.Photo.CopyToAsync(ms);
                    photoBytes = ms.ToArray();
                }
            }



            var owner = new Owner
            {
                Name = createOwnerDto.Name,
                Address = createOwnerDto.Address,
                BirthDate = createOwnerDto.BirthDate,
                Photo = photoBytes
            };

            await _ownerRepository.CreateOwner(owner);
            return owner;
        }

        public async Task<Owner?> GetOwnerByIdAsync(string id)
        {
            return await _ownerRepository.GetOwnerById(id);
        }

        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllOwners();
        }

        public async Task<Owner> UpdateOwnerAsync(string id, UpdateOwnerDto updateOwnerDto)
        {

            byte[] photoBytes = null;

            if (updateOwnerDto.Photo != null && updateOwnerDto.Photo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await updateOwnerDto.Photo.CopyToAsync(ms);
                    photoBytes = ms.ToArray();
                }
            }

            var owner = new Owner
            {
                Id = id,
                Name = updateOwnerDto.Name,
                Address = updateOwnerDto.Address,
                BirthDate = updateOwnerDto.BirthDate,
                Photo = photoBytes
            };

            return await _ownerRepository.UpdateOwner(owner);
        }

        public async Task<bool> DeleteOwnerAsync(string id)
        {
            return await _ownerRepository.DeleteOwner(id);
        }
    }
}