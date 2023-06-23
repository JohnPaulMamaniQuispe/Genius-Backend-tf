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

    public async  Task<bool> CreateAsync(Owner input)
    {
        return await _ownerInfraestructure.CreateAsync(input);
        
    }

    public  Task<bool> Update(int id, Owner input)
    {
        return  _ownerInfraestructure.Update(id,input);
    }

    public  Task<bool> Delete(int id)
    {
        return  _ownerInfraestructure.Delete(id);
    }
}