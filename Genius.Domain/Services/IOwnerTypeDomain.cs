using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface IOwnerTypeDomain
{
    public Task<List<OwnerType>> GetAll();
    Task <Boolean>CreateAsync(OwnerType ownerType );
    Task <Boolean>Update(int id, OwnerType input);
    Task<Boolean> Delete(int id);
}