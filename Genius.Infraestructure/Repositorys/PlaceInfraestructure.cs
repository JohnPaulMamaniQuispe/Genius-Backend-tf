using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class PlaceInfraestructure: IPlaceInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public PlaceInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }


    public async Task<List<Place>> GetAll()
    {
        return await _geniusDbContext.Places.Where(place=> place.IsActive).ToListAsync(); 
    }

    public  Place GetById(int id)
    {
        return _geniusDbContext.Places.Single(place=> place.IsActive && place.Id ==id);
    }

    public async Task<bool> CreateAsync(Place place)
    {
        try
        {
            place.IsActive = true;
            place.DateCreated = DateTime.Now;
            await _geniusDbContext.Places.AddAsync(place);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
        
    }

    public async Task<bool> Update(int id, Place input)
    {
        try
        {
            var place = _geniusDbContext.Places.Find(id); // var son procesados antes de iniciar codigo 
            place.IsFree = input.IsFree;
            place.DateUpdated = DateTime.Now;
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
        var place = _geniusDbContext.Places.Find(id); //obtengo con id
        place.IsActive = false;
        _geniusDbContext.Places.Remove(place);
        _geniusDbContext.Places.Update(place);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}