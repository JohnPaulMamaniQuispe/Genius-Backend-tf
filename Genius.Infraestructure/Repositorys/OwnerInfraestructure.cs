using Genius.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class OwnerInfraestructure:IOwnerInfraestructure
{

    private GeniusDBContext _geniusDbContext;

    public OwnerInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }


    public  async Task<List<Owner>> GetAll()
    {
        return await _geniusDbContext.Owners.Where(owner => owner.IsActive).ToListAsync();
    }

    public Task<List<Owner>> GetByfirtname(string firtname)
    {
        throw new NotImplementedException();
    }

    public Owner GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(Owner input)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(int id, Owner input)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}