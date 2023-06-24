using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface IParkingDomain
{
    public Task<List<Parking>> GetAll();
    Task <Boolean>CreateAsync(Parking parking);
    Task <Boolean>Update(int id, Parking input);
    Task<Boolean> Delete(int id);
}