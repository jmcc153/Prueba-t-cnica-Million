using MongoDB.Driver;
using technical_test.Core.Entities;
using technical_test.Core.Interfaces;

namespace technical_test.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IMongoCollection<Owner> _owners;

        public OwnerRepository(IMongoDatabase database)
        {
            _owners = database.GetCollection<Owner>("Owner");
        }

        public async Task<Owner> CreateOwner(Owner owner)
        {
            await _owners.InsertOneAsync(owner);
            return owner;
        }

        public async Task<Owner> GetOwnerById(string id)
        {
            return await _owners.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            return await _owners.Find(_ => true).ToListAsync();
        }

        public async Task<Owner> UpdateOwner(Owner owner)
        {
            await _owners.ReplaceOneAsync(o => o.Id == owner.Id, owner);
            return owner;
        }

        public async Task<bool> DeleteOwner(string id)
        {
            var result = await _owners.DeleteOneAsync(o => o.Id == id);
            return result.DeletedCount > 0;
        }
    }
}