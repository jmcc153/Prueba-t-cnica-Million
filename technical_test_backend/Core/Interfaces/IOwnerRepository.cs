using technical_test.Core.Entities;

namespace technical_test.Core.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> CreateOwner(Owner owner);
        Task<Owner> GetOwnerById(string id);
        Task<List<Owner>> GetAllOwners();
        Task<Owner> UpdateOwner(Owner owner);
        Task<bool> DeleteOwner(string id);
    }
}
