using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IReservationInfraestructure
{
    
    Task<List<Reservation>> GetAll();
    
    Reservation GetById(int id); 
    //bool Create(string name, int age, string license, string phone);
    Task <Boolean> CreateAsync(Reservation reservation);
    Task <Boolean>Update(int id, Reservation input);
    Task <Boolean> Delete(int id);

}