using Genius.Infraestructure;

namespace Genius.Domain;

public interface IOwnerDomain
{
       
    public Task<List<Owner>> GetAll();
    Task <Boolean>CreateAsync(Owner input);
    Task <Boolean>Update(int id,  Owner input);
    Task<Boolean> Delete(int id);
}