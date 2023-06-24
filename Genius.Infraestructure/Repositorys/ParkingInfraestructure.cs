using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class ParkingInfraestructure:IParkingInfraestructure
{
    private GeniusDBContext _geniusDbContext;

    public ParkingInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    
    
    
    public async Task<List<Parking>> GetAll()
    {
        return await _geniusDbContext.Parkings.Where(driver=> driver.IsActive).ToListAsync(); 
    }

    public async Task<List<Parking>> GetByAddress(string address)
    {
        return await  _geniusDbContext.Parkings.Where(parking => parking.IsActive && parking.Address.Contains(address)).ToListAsync();
    }

    public Parking GetById(int id)
    {
        return _geniusDbContext.Parkings.Single(parking=> parking.IsActive && parking.Id ==id);
    }

    public async Task<bool> CreateAsync(Parking parking)
    {
        try
        {
            parking.IsActive = true;
            parking.DateCreated = DateTime.Now;
            await _geniusDbContext.Parkings.AddAsync(parking);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
    }

    public async Task<bool> Update(int id, Parking input)
    {
        
        try
        {
            var parking = _geniusDbContext.Parkings.Find(id); // var son procesados antes de iniciar codigo 
            parking.CostPerHour = input.CostPerHour;
            parking.PenaltyFee = input.PenaltyFee;
            parking.Address = input.Address;
            parking.TotalSpace = input.TotalSpace;
            parking.OpeningTime = input.OpeningTime;
            parking.ClosingTime = input.ClosingTime;
            parking.DateUpdated = DateTime.Now;
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
        var parking = _geniusDbContext.Parkings.Find(id); //obtengo con id
        parking.IsActive = false;
        _geniusDbContext.Parkings.Remove(parking);
        _geniusDbContext.Parkings.Update(parking);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}