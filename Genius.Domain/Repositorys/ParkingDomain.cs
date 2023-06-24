using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class ParkingDomain:IParkingDomain
{
    private IParkingInfraestructure _parkingInfraestructure;

    public ParkingDomain(IParkingInfraestructure parkingInfraestructure)
    {
        _parkingInfraestructure = parkingInfraestructure;
    }
    
    public Task<List<Parking>> GetAll()
    {
        return _parkingInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(Parking parking)
    {
        return await _parkingInfraestructure.CreateAsync(parking);
    }

    public async Task<bool> Update(int id, Parking parking)
    {
        return await _parkingInfraestructure.Update(id, parking);
    }

    public async Task<bool> Delete(int id)
    {
        return await _parkingInfraestructure.Delete(id);

    }
}