using Genius.Infraestructure.Models;

namespace Genius.Infraestructure;

public interface IParkingInfraestructure
{
    Task<List<Parking>> GetAll();
    Task<List<Parking>> GetByAddress(string address);
    Parking GetById(int id);
    Task <Boolean> CreateAsync(Parking parking);
    Task <Boolean>Update(int id, Parking input);
    Task <Boolean> Delete(int id);
}