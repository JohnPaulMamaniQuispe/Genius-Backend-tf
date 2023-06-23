using Genius.Infraestructure;

namespace Genius.Domain;

public interface IOwnerDomain
{
       
    public Task<List<Owner>> GetAll();
    Task <bool>CreateAsync(Owner input);
    Task <bool>Update(int id,  Owner input);
    Task<bool> Delete(int id);
}