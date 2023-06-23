using Genius.Infraestructure.Models;

namespace Genius.Domain;

public interface ICarDomain
{
    public Task<List<Car>> GetAll();
    //bool Create(string name, int age, string license, string phone);
    Task<bool>  CreateAsync(Car input);
    bool Update(int id, Car input);
    bool Delete(int id);
}