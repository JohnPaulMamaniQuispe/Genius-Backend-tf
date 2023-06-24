using Genius.Infraestructure;

namespace Genius.Domain;

public class OwnerDomain:IOwnerDomain
{
    private IOwnerInfraestructure _ownerInfraestructure;

    public OwnerDomain(IOwnerInfraestructure ownerInfraestructure)
    {
        _ownerInfraestructure = ownerInfraestructure;
    }
    public Task<List<Owner>> GetAll()
    {
        return _ownerInfraestructure.GetAll();
    }

    public async  Task<bool> CreateAsync(Owner owner)
    {
        return await _ownerInfraestructure.CreateAsync(owner);
        
    }

    public  async Task<bool> Update(int id, Owner owner)
    {
        return  await  _ownerInfraestructure.Update(id, owner);
    }

    public async Task<bool> Delete(int id)
    {
        return await _ownerInfraestructure.Delete(id);
    }
}