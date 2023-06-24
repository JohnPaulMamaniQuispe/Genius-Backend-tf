using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class OwnerTypeDomain:IOwnerTypeDomain
{
    private IOwnerTypeInfraestructure _ownerTypeInfraestructure;

    public OwnerTypeDomain(IOwnerTypeInfraestructure ownerTypeInfraestructure)
    {
        _ownerTypeInfraestructure = ownerTypeInfraestructure;
    }
    
    
    public Task<List<OwnerType>> GetAll()
    {
        return _ownerTypeInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(OwnerType ownerType)
    {
        return await _ownerTypeInfraestructure.CreateAsync(ownerType);
    }

    public async Task<bool> Update(int id, OwnerType input)
    {
        return await _ownerTypeInfraestructure.Update(id, input);
    }

    public async Task<bool> Delete(int id)
    {
        return await _ownerTypeInfraestructure.Delete(id);
    }
}