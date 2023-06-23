using Genius.Infraestructure;
using Genius.Infraestructure.Models;

namespace Genius.Domain;

public class CarDomain:ICarDomain
{
    private ICarInfraestructure _carInfraestructure;
    public CarDomain(ICarInfraestructure carInfraestructure)
    {
        _carInfraestructure=carInfraestructure;
    }

    public Task<List<Car>> GetAll()
    {
        return _carInfraestructure.GetAll();
    }

    public async Task<bool> CreateAsync(Car input)
    {
        return await _carInfraestructure.Create(input);
    }
    
    public bool Update(int id, Car input)
    {
        return _carInfraestructure.Update(id, input);
    }

    public bool Delete(int id)
    {
        return _carInfraestructure.Delete(id);
    }
}