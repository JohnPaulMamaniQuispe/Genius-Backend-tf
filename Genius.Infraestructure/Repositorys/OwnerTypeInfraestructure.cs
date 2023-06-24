using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class OwnerTypeInfraestructure: IOwnerTypeInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public OwnerTypeInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    
    public async Task<List<OwnerType>> GetAll()
    {
        return await _geniusDbContext.OwnerTypes.Where(ownerType=> ownerType.IsActive).ToListAsync();
        
    }

    public  OwnerType GetById(int id)
    {
        return _geniusDbContext.OwnerTypes.Single(ownerType=> ownerType.IsActive && ownerType.Id ==id); 
    }

    public async Task<bool> CreateAsync(OwnerType ownerType)
    {
        try
        {
            ownerType.IsActive = true;
            ownerType.DateCreated = DateTime.Now;
            await _geniusDbContext.OwnerTypes.AddAsync(ownerType);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
    }

    public async Task<bool> Update(int id, OwnerType input)
    {
        try
        {
            var ownerType = _geniusDbContext.OwnerTypes.Find(id); // var son procesados antes de iniciar codigo 
            ownerType.NameType = input.NameType;
            ownerType.DateUpdated = DateTime.Now;
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
        var ownerType = _geniusDbContext.OwnerTypes.Find(id); //obtengo con id
        ownerType.IsActive = false;
        _geniusDbContext.OwnerTypes.Remove(ownerType);
        _geniusDbContext.OwnerTypes.Update(ownerType);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}