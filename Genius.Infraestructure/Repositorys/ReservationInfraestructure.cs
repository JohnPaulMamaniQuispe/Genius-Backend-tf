using Genius.Infraestructure.Context;
using Genius.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class ReservationInfraestructure: IReservationInfraestructure
{

    private GeniusDBContext _geniusDbContext;

    public ReservationInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    
    
    
    public async Task<List<Reservation>> GetAll()
    {
        return await _geniusDbContext.Reservations.Where(reservation=>  reservation.IsActive).ToListAsync();
    }

    public Reservation GetById(int id)
    {
        
        return _geniusDbContext.Reservations.Single(reservation=> reservation.IsActive && reservation.Id ==id);
        
    }

    public async Task<bool> CreateAsync(Reservation reservation)
    {
        try
        {
            reservation.IsActive = true;
            reservation.DateCreated = DateTime.Now;
            await _geniusDbContext.Reservations.AddAsync(reservation);
            await _geniusDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            throw;
            return false;
        }
        
        
    }

    public async Task<bool> Update(int id, Reservation input)
    {
        try
        {
            var reservation = _geniusDbContext.Reservations.Find(id); // var son procesados antes de iniciar codigo 
            reservation.TotalCost = input.TotalCost;
            reservation.DueDate = input.DueDate;
            reservation.TotalCost = input.TotalCost;
            reservation.DateUpdated = DateTime.Now;
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
        var reservation = _geniusDbContext.Reservations.Find(id); //obtengo con id
        reservation.IsActive = false;
        _geniusDbContext.Reservations.Remove(reservation);
        _geniusDbContext.Reservations.Update(reservation);
        await _geniusDbContext.SaveChangesAsync();
        return true;
    }
}