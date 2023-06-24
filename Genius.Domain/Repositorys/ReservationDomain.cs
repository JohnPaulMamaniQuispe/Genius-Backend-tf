using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class ReservationDomain:IReservationDomain
{
    private IReservationInfraestructure _reservationInfraestructure;

    public ReservationDomain(IReservationInfraestructure reservationInfraestructure)
    {
        _reservationInfraestructure = reservationInfraestructure;
    }
    
    
    public Task<List<Reservation>> GetAll()
    {
        return _reservationInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(Reservation reservation)
    {
        return await _reservationInfraestructure.CreateAsync(reservation);
    }

    public async Task<bool> Update(int id, Reservation input)
    {
        return await _reservationInfraestructure.Update(id, input);
    }

    public async Task<bool> Delete(int id)
    {
        return await _reservationInfraestructure.Delete(id);
    }
}