using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface IReservationDomain
{
    public Task<List<Reservation>> GetAll();
    Task <Boolean>CreateAsync(Reservation reservation);
    Task <Boolean>Update(int id, Reservation input);
    Task<Boolean> Delete(int id);
}