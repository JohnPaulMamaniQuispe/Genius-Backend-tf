using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IOwnerTypeInfraestructure
{
    
    Task<List<OwnerType>> GetAll();
    OwnerType GetById(int id);
    Task <Boolean> CreateAsync(OwnerType ownerType);
    Task <Boolean>Update(int id, OwnerType input);
    Task <Boolean> Delete(int id);
}