using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class DriverInfraestructure: IDriverInfraestructure
{

    private GeniusDBContext _geniusDbContext;

    public DriverInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }

    public async Task<List<Driver>> GetAll()
    {
        //return _geniusDbContext.Drivers.ToList();
       return await _geniusDbContext.Drivers.Where(driver=> driver.IsActive).ToListAsync(); //solo filtramos los activos con expresiones lambda
       //return _geniusDbContext.Drivers.Where(driver=> driver.IsActive).ToList();
    }

    public async Task<List<Driver>> GetByName(string name)
    {
        //return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name == name).ToList(); //Nombre exacto
        return await  _geniusDbContext.Drivers.Where(driver => driver.IsActive && driver.Name.Contains(name)).ToListAsync(); //Contiene parte
    }


    public Driver GetById(int id)
    {
        return _geniusDbContext.Drivers.Single(driver=> driver.IsActive && driver.Id ==id); //solo se implementa en capa estructure
    }

    public async Task<bool> CreateAsync( Driver driver)
    {
            try
            {
                driver.IsActive = true;
                driver.DateCreated = DateTime.Now;
                await _geniusDbContext.Drivers.AddAsync(driver);
                await _geniusDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw;
                return false;
            }
    }
    

    public async Task<bool> Update(int id, Driver input)
    {
        try
        {
            var driver = _geniusDbContext.Drivers.Find(id); // var son procesados antes de iniciar codigo 
            driver.Name = input.Name;
            driver.Age = input.Age;
            driver.License = input.License;
            driver.Phone = input.Phone;
            driver.DateUpdated = DateTime.Now;
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }
    
    public async Task<bool>  Delete(int id)
    {
        var driver = _geniusDbContext.Drivers.Find(id); //obtengo con id
        driver.IsActive = false;
        _geniusDbContext.Drivers.Remove(driver);
        _geniusDbContext.Drivers.Update(driver);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
    
}

