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

    public async Task<List<Owner>> GetByFirtname(string firtname)
    {
        //return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name == name).ToList(); //Nombre exacto
        return await  _geniusDbContext.Owners.Where(owner => owner.IsActive && owner.FirstName.Contains(firtname)).ToListAsync(); //Contiene parte
    }

    public Owner GetById(int id)
    {
        return _geniusDbContext.Owners.Single(owner=> owner.IsActive && owner.Id ==id);
    }

    public async Task<bool> CreateAsync(Owner owner)
    {
        try
        {
            owner.IsActive = true;
            owner.DateCreated = DateTime.Now;
            await _geniusDbContext.Owners.AddAsync(owner);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
    }

    public async Task<bool> Update(int id, Owner input)
    {
        try
        {
            var owner = _geniusDbContext.Owners.Find(id); // var son procesados antes de iniciar codigo 
            owner.FirstName = input.FirstName;
            owner.LastName = input.LastName;
            owner.Phone = input.Phone;
            owner.Email = input.Email;
            owner.DateUpdated = DateTime.Now;
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var owner = _geniusDbContext.Owners.Find(id); //obtengo con id
        owner.IsActive = false;
        _geniusDbContext.Owners.Remove(owner);
        _geniusDbContext.Owners.Update(owner);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}