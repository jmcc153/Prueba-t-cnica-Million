using technical_test.Application.DTOs.Owner;
using technical_test.Core.Entities;

namespace technical_test.Application.Interfaces
{
    public interface IOwnerService
    {
        Task<Owner> CreateOwnerAsync(CreateOwnerDto createOwnerDto);
        Task<Owner?> GetOwnerByIdAsync(string id);
        Task<List<Owner>> GetAllOwnersAsync();
        Task<Owner> UpdateOwnerAsync(string id,UpdateOwnerDto updateOwnerDto);
        Task<bool> DeleteOwnerAsync(string id);
    }
}